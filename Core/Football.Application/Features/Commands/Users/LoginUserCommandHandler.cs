using AutoMapper;
using Football.Application.DTO;
using Football.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Football.Application.Features.Commands.Users
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserLoginReponseDTO>
    {
        private readonly IUserService userService;

        public LoginUserCommandHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<UserLoginReponseDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await userService.Login(request.UserName, request.Password);
           
            return dbUser;
        }
    }
}
