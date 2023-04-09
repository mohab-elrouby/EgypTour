using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LocalReview : Review
    {
        public int PersonReviewdId { get; private set; }
        public virtual LocalPerson PersonReviewd { get; private set; }
        public LocalReview(float rating, Tourist writer, string? content) : base(rating, writer, content)
        {
        }
        private LocalReview() { }

    }

   
}
