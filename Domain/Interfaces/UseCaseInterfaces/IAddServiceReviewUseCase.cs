using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCaseInterfaces
{
    public interface IAddServiceReviewUseCase
    {
        public void AddReview(ReviewDTO review, int ServiceId, int userId);
    }
}
