using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class LocalReviewDTO
    {
        public int Id { get;  set; }
        public DateTime Date { get; set; }
        public string? Content { get; set; }

        public float Rating { get; set; }
        public int LocalPersonId { get;  set; }
      
        public ReviewerDTO reviewer { get; set; }

        public static LocalReviewDTO fromLocalReview(LocalReview review)
        {
            return new LocalReviewDTO
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

