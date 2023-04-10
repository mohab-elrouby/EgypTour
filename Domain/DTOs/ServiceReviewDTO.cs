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
        public TouristDTO reviewer { get; set; } = new();
        public static ServiceReviewDTO FromServiceReview(ServiceReview review)
        {
            return new ServiceReviewDTO
            {
                Id = review.Id,
                Date = review.Time,
                Content = review.Content,
                Rating = review.Rating,
                reviewer = TouristDTO.FromTourist(review.Reviwer),
            };
        }
    }
}
