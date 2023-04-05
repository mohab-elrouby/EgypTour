using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.UseCaseInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AddServiceReviewUseCase : IAddServiceReviewUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public AddServiceReviewUseCase(IUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }

        public void AddReview(ReviewDTO review,int ServiceId,int userId)
        {
            if (UserReviewdService(userId, ServiceId))
            {
                throw new ArgumentException("Tourist Already have a review for this service");
            }
            else
            {
                Service service = _unitOfWork._services.GetById(ServiceId);
                if (service == null)
                {
                    throw new ArgumentException($"Service {ServiceId} Doesn't Exist");
                }
                Tourist tourist = _unitOfWork._tourists.GetById(userId);
                if(tourist == null)
                {
                    throw new ArgumentException($"User {userId} Doesn't Exist");
                }
                service.AddReview(review.Content, review.Rating, tourist);
                //presist data
                _unitOfWork.Commit();
            }
        }

        private bool UserReviewdService(int userId,int ServiceId)
        {
            bool flag  = _unitOfWork._serviceReviews.Find(i=>i.ServiceReviewdId== ServiceId&&i.ReviwerId== userId).Any();
            return flag;
        }
    }
}
