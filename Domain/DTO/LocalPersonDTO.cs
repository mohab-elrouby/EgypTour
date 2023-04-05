using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class LocalPersonDTO
    {
        public int Id { get;  set; }
        public string Fname { get;  set; }

        public string Lname { get;  set; }
        public string Email { get;  set; }

        public string UsernameName { get;  set; }

        public string Password { get;  set; }

        public string ProfilePictureUrl { get;  set; }

        public string City { get;  set; }

        public string Phone { get;  set; }
    }
}
