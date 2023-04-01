using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Content { get;  set; }

        public float Rating { get;  set; }
        public ReviewerDTO reviewer { get;  set; }

        public static ReviewDto FromReview(Review review)
        {
            return new ReviewDto()
            {
                Id = review.Id,
                Content = review.Content,
                Rating = review.Rating,
                reviewer = ReviewerDTO.FromTourist(review.Reviwer)
            };
        }
    }
}
