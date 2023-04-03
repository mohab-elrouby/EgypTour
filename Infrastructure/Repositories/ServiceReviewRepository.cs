using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ServiceReviewRepository : GenericRepository<ServiceReview>, IServiceReviewRepository
    {
        private readonly EgyTourContext _db;
        public ServiceReviewRepository(EgyTourContext db) : base(db)
        {

            _db = db;
        }
        public IEnumerable<ServiceReview> GetByTouristId(int id, int skip , int take)
        {
            IEnumerable<ServiceReview> reviews = _db.ServiceReviews.Where(x => x.ReviwerId== id).Include("Reviwer").Skip(skip).Take(take);
            return reviews;
        }

        public IEnumerable<ServiceReview> GetByServiceId(int id, int skip, int take)
        {
            IEnumerable<ServiceReview> reviews = _db.ServiceReviews.Where(x => x.ServiceReviewdId== id).Include("Reviwer").Skip(skip).Take(take);
            return reviews;
        }
    }
}
