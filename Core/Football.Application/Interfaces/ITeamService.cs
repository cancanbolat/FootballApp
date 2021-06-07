using Football.Application.DTO;
using Football.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Application.Interfaces
{
    public interface ITeamService : IMainService<Team, int>
    {
        
    }
}
