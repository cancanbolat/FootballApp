using Football.Application.DTO;
using Football.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Core.Application.Features.Commands.Players
{
    public class CreatePlayerCommand : IRequest<ServiceResponse<Guid>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TeamId { get; set; }
        public int PositionId { get; set; }
    }
}
