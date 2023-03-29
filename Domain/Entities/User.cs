using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
     public class User
    {
        public int Id { get; private set; }
        public string Fname { get; private set; }

        public string Lname { get; private set; }
        public string Email { get; private set; }

        public string UsernameName { get; private set; }

        public string  Password { get; private set; }

        public string ProfilePictureUrl { get; private set; }

        public string City { get; private set; }

        public string Phone { get; private set; }

        public virtual List<Messege> SentMessages { get; private set; } = new();

        public virtual List<Messege> RecievedMessages { get; private set; } = new();

    }
}
