using AutoMapper;
using Football.Application.DTO;
using Football.Application.Interfaces;
using Football.Core.Entities;
using Football.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Football.Infrastructure.Persistence.Services
{
    public class UserService : PlayerUserGenericService<User>, IUserService
    {
        private readonly FootballDbContext dbContext;
        private readonly IConfiguration Configuration;
        private readonly IMapper mapper;

        public UserService(FootballDbContext dbContext, IConfiguration configuration, IMapper mapper) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.Configuration = configuration;
            this.mapper = mapper;
        }

        public async Task<UserLoginReponseDTO> Login(string UserName, string Password)
        {
            var dbUser = await dbContext.Users.Where(u => u.UserName == UserName && u.Password == Password).FirstOrDefaultAsync();

            if (dbUser == null)
                throw new Exception("User not found");

            UserLoginReponseDTO result = new UserLoginReponseDTO();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(int.Parse(Configuration["JwtExpiryInDate"].ToString()));

            //Payload
            var claims = new[]
            {
                new Claim(System.Security.Claims.ClaimTypes.Name, UserName)
            };

            //Generate Token
            var token = new JwtSecurityToken(Configuration["JwtIssuer"], Configuration["JwtAudience"],
                claims, null, expiry, credentials
            );

            result.ApiToken = new JwtSecurityTokenHandler().WriteToken(token);
            result.UserDTO = mapper.Map<UserDTO>(dbUser);

            return result;
        }
    }
}
