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
    public class TripRepository: GenericRepository<Trip>, ITripRepository
    {
        private readonly EgyTourContext _db;
        public TripRepository(EgyTourContext db) : base(db)
        {
            _db = db;
        }

       
    }
}
