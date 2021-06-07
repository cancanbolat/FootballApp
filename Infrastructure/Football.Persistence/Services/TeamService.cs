using Football.Application.DTO;
using Football.Application.Interfaces;
using Football.Core.Entities;
using Football.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Infrastructure.Persistence.Services
{
    public class TeamService : TeamPosGenericService<Team>, ITeamService
    {
        private readonly FootballDbContext dbContext;

        public TeamService(FootballDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
