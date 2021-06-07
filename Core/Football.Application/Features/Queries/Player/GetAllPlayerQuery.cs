using AutoMapper;
using Football.Application.DTO;
using Football.Application.Interfaces;
using Football.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Football.Application.Features.Commands.Players
{
    public class GetAllPlayerQuery : IRequest<ServiceResponse<List<PlayerDTO>>>
    {
        public class GetAllPlayerHandler : IRequestHandler<GetAllPlayerQuery, ServiceResponse<List<PlayerDTO>>>
        {
            private readonly IPlayerService service;
            private readonly IMapper mapper;

            public GetAllPlayerHandler(IPlayerService service, IMapper mapper)
            {
                this.service = service;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<PlayerDTO>>> Handle(GetAllPlayerQuery request, CancellationToken cancellationToken)
            {
                var players = await service.GetAll();
                var results = mapper.Map<List<PlayerDTO>>(players);

                return new ServiceResponse<List<PlayerDTO>>()
                {
                    Value = results,
                    Message = $"Player count: {results.Count()}"
                };
            }
        }
    }
}
