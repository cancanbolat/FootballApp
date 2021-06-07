using AutoMapper;
using Football.Application.Interfaces;
using Football.Application.Wrappers;
using Football.Core.Application.DTO;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Football.Core.Application.Features.Queries.Team
{
    public class GetAllTeamQuery : IRequest<ServiceResponse<List<TeamDTO>>>
    {
        public class GetTeamsQueryHandler : IRequestHandler<GetAllTeamQuery, ServiceResponse<List<TeamDTO>>>
        {
            private readonly ITeamService teamService;
            private readonly IMapper mapper;
            private readonly IDistributedCache distributedCache;

            public GetTeamsQueryHandler(ITeamService teamService, IMapper mapper, IDistributedCache distributedCache)
            {
                this.teamService = teamService;
                this.mapper = mapper;
                this.distributedCache = distributedCache;
            }

            public async Task<ServiceResponse<List<TeamDTO>>> Handle(GetAllTeamQuery request, CancellationToken cancellationToken)
            {
                var teams = await teamService.GetAll();
                var result = mapper.Map<List<TeamDTO>>(teams);

                var cacheKey = $"players-{result}";
                var cacheData = await distributedCache.GetStringAsync(cacheKey);
                await distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(result));

                if (cacheData != null)
                {
                    var cacheTeams = JsonConvert.DeserializeObject<List<TeamDTO>>
                        (await distributedCache.GetStringAsync(cacheKey));
                    return new ServiceResponse<List<TeamDTO>>() { Value = cacheTeams };
                }

                return new ServiceResponse<List<TeamDTO>>()
                {
                    Value = result,
                    Message = $"Team count: {result.Count()}"
                };
            }
        }
    }
}
