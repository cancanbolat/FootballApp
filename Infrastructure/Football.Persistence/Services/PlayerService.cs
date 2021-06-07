using Football.Application.DTO;
using Football.Application.Interfaces;
using Football.Core.Entities;
using Football.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Infrastructure.Persistence.Services
{
    public class PlayerService : PlayerUserGenericService<Player>, IPlayerService
    {
        private readonly FootballDbContext dbContext;

        public PlayerService(FootballDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<DetailedPlayerDTO> GetDetailed(Guid id)
        {
            var query = await dbContext.Players
                .Include(x => x.Positions)
                .Include(x => x.Team)
                .Select(x => new DetailedPlayerDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Photo = x.Photo,
                    Position = x.Positions.Name,
                    Team = x.Team.Name
                }).Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return query;
        }
    }
}

