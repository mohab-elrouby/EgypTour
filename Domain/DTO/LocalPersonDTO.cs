using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class LocalPersonDTO
    {
        public int Id { get; private set; }
        public string Fname { get; private set; }

        public string Lname { get; private set; }
        public string Email { get; private set; }

        public string UsernameName { get; private set; }

        public string Password { get; private set; }

        public string ProfilePictureUrl { get; private set; }

        public string City { get; private set; }

        public string Phone { get; private set; }
    }
}
