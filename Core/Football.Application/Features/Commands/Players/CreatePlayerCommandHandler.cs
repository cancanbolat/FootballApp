using AutoMapper;
using Football.Application.DTO;
using Football.Application.Interfaces;
using Football.Application.Wrappers;
using Football.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Football.Core.Application.Features.Commands.Players
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, ServiceResponse<Guid>>
    {
        private readonly IPlayerService playerService;
        private readonly IMapper mapper;

        public CreatePlayerCommandHandler(IPlayerService playerService, IMapper mapper)
        {
            this.playerService = playerService;
            this.mapper = mapper;
        }

        public async Task<ServiceResponse<Guid>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = mapper.Map<Player>(request);
            await playerService.Create(player);

            return new ServiceResponse<Guid>() { Value = player.Id };
        }
    }
}
