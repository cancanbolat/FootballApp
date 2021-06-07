using AutoMapper;
using Football.Application.Wrappers;
using Football.Core.Application.DTO;
using Football.Core.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Football.Core.Application.Features.Queries.Position
{
    public class GetAllPositionQuery : IRequest<ServiceResponse<List<PositionDTO>>>
    {
        public class GetPositionQueryHandler : IRequestHandler<GetAllPositionQuery, ServiceResponse<List<PositionDTO>>>
        {
            private readonly IPositionService positionService;
            private readonly IMapper mapper;
            private readonly IDistributedCache distributedCache;

            public GetPositionQueryHandler(IPositionService positionService, IMapper mapper, IDistributedCache distributedCache)
            {
                this.positionService = positionService;
                this.mapper = mapper;
                this.distributedCache = distributedCache;
            }
            public async Task<ServiceResponse<List<PositionDTO>>> Handle(GetAllPositionQuery request, CancellationToken cancellationToken)
            {
                var positions = await positionService.GetAll();
                var result = mapper.Map<List<PositionDTO>>(positions);

                var cacheKey = $"positions-{result}";
                var cacheData = await distributedCache.GetStringAsync(cacheKey);
                await distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(result));

                if (cacheData != null)
                {
                    var cachePositions = JsonConvert.DeserializeObject<List<PositionDTO>>
                        (await distributedCache.GetStringAsync(cacheKey));
                    return new ServiceResponse<List<PositionDTO>>() { Value = cachePositions };
                }

                return new ServiceResponse<List<PositionDTO>>()
                {
                    Value = result,
                    Message = $"Position count: {result.Count()}"
                };
            }
        }
    }
}
