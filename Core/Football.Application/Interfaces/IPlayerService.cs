using Football.Application.DTO;
using Football.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Application.Interfaces
{
    public interface IPlayerService : IMainService<Player, Guid>
    {
        public Task<DetailedPlayerDTO> GetDetailed(Guid id);
    }
}
