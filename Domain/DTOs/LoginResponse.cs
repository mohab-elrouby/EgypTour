using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class LoginResponse
    {
        public string Status { get; set; }
        public string Token { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}
