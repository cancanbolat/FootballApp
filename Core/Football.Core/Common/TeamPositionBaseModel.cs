using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Core.Common
{
    public class TeamPositionBaseModel : IEntity<int>
    {
        public int Id { get; set; }
    }
}
