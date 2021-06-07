using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Core.Common
{
    public class BaseModel : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
