using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ReviewDTO
    {
        public int Id { get;private set; }
        public string Content { get; set; } = "";

        public float Rating { get;  set; }
        public ReviewerDTO? Reviewer { get; private set; }

        public static ReviewDTO FromReview(Review review)
        {
            return new ReviewDTO()
            {
                Id = review.Id,
                Content = review.Content,
                Rating = review.Rating,
                Reviewer = ReviewerDTO.FromTourist(review.Reviwer)
            };
        }
    }
}
