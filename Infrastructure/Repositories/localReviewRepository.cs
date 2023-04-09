using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class localReviewRepository:GenericRepository<LocalReview>,ILocalReviewRepository
    {
        private readonly EgyTourContext _db;
        public localReviewRepository(EgyTourContext db):base(db) { 

            _db = db;
        }

        public IEnumerable<LocalReview> GetByLocalPersonId(int id, int skip, int take)
        {
            var reviews = _db.LocalReviews.Where(x=>x.PersonReviewdId== id).Include("Reviwer").Skip(skip).Take(take);
            return reviews;

            
        }
    }
}
