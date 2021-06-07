using Football.Core.Application.Interfaces;
using Football.Core.Entities;
using Football.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Infrastructure.Persistence.Services
{
    public class PositionService : TeamPosGenericService<Position>, IPositionService
    {
        public PositionService(FootballDbContext dbContext) : base(dbContext)
        {
        }
    }
}
