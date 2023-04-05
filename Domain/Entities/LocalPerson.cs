using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
     public class LocalPerson : User
    {
        public virtual List<LocalReview> Reviews { get; private set; } = new();

        public CityName City { get; private set;}
        public LocalPerson(CityName city,string fname, string lname, string email, string userName, string password, string phone, string profilePictureUrl = "")
            :base(fname, lname, email, userName, password, phone, profilePictureUrl)
        {
            City = city;
        }
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
    }
}
