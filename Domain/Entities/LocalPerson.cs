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
    }
}
