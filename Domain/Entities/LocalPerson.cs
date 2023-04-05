using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
     public class LocalPerson : User
    {
        public virtual List<LocalReview> Reviews { get; private set; }
        public void rate(LocalReview review)
        {
            if (review != null)
            {
                Reviews.Add(review);
            }
            else
            {
                throw new ArgumentNullException("review must not be null");
            }
        }

        public LocalPerson(string fname, string lname, string email, string usernameName,
            string password, string city, string phone, string profilePictureUrl):base(fname,lname,email,
                usernameName,password,city,phone,profilePictureUrl)
        { }
    }
}
