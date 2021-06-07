using Football.Application.DTO;
using Football.Application.Interfaces;
using Football.Application.Wrappers;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Football.Application.Features.Commands.Players
{
    public class GetPlayerDetailQuery : IRequest<ServiceResponse<DetailedPlayerDTO>>
    {
        public Guid Id { get; set; }

        public class GetPlayerDetailHandler : IRequestHandler<GetPlayerDetailQuery, ServiceResponse<DetailedPlayerDTO>>
        {
            private readonly IPlayerService service;
            private readonly IDistributedCache distributedCache;

            public GetPlayerDetailHandler(IPlayerService service, IDistributedCache distributedCache)
            {
                this.service = service;
                this.distributedCache = distributedCache;
            }

            public async Task<ServiceResponse<DetailedPlayerDTO>> Handle(GetPlayerDetailQuery request, CancellationToken cancellationToken)
            {
                var player = await service.GetDetailed(request.Id);

                var cacheKey = $"playerdetails{request.Id}";

                var cacheData = await distributedCache.GetStringAsync(cacheKey);
                await distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(player));

                if (cacheData != null)
                {
                    var cachePlayer = JsonConvert.DeserializeObject<DetailedPlayerDTO>
                        (await distributedCache.GetStringAsync(cacheKey));

                    return new ServiceResponse<DetailedPlayerDTO>() { Value = cachePlayer };
                }

                return new ServiceResponse<DetailedPlayerDTO>() { Value = player };
            }

        }
    }

}