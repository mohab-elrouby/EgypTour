using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        private readonly EgyTourContext _db;
        public ActivityRepository(EgyTourContext db) : base(db)
        {
            _db= db;
        }

        public IEnumerable<Activity> GetByTripId(int TripId)
        {
            return _db.Activities.Where(a => a.TripId == TripId);
        }
    }
}
