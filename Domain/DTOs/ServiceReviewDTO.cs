using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ServiceReviewDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Content { get; set; }

        public float Rating { get; set; }
       
        public int ServiceId { get; set; }
        public ReviewerDTO reviewer { get; set; }
        public static ServiceReviewDTO fromServiceReview(ServiceReview review)
        {
            return new ServiceReviewDTO
            {
                Id = review.Id,
                Date = review.Time,
                Content = review.Content,
                Rating = review.Rating,
                reviewer = ReviewerDTO.FromTourist(review.Reviwer),
            };
        }
    }
}
