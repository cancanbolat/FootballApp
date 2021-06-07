using Football.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Core.Entities
{
    public class Player : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }


        public int TeamId { get; set; }
        public int PositionId { get; set; }

        public virtual Team Team { get; set; }
        public virtual Position Positions { get; set; }
    }
}
