using Football.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Application.Features.Commands.Users
{
    public class LoginUserCommand : IRequest<UserLoginReponseDTO>
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
