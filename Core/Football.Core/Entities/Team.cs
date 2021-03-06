using Football.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Core.Entities
{
    public class Team : TeamPositionBaseModel
    {
        public string Name { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
