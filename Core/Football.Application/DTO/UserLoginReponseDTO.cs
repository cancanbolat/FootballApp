using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Application.DTO
{
    public class UserLoginReponseDTO
    {
        public string ApiToken { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}
