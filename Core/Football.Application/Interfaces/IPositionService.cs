using Football.Application.Interfaces;
using Football.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Core.Application.Interfaces
{
    public interface IPositionService : IMainService<Position, int>
    {
    }
}
