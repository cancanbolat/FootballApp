using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Application.DTO
{
    public class TeamPlayersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlayerFirstName { get; set; }
        public string PlayerLastName { get; set; }
    }
}
