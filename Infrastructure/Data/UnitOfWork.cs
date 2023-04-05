using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EgyTourContext _context;
        public IPostRepository Posts { get; private set; }

        public ILocalReviewRepository LocalReviews { get; private set; }
        public IServiceReviewRepository ServiceReviews { get; private set; }
        public ITripRepository Trips { get; private set; }

        public UnitOfWork(EgyTourContext context , ILocalReviewRepository localReviews , IServiceReviewRepository serviceReviews , ITripRepository trips )
        {
            _context=context;
            Posts = new PostRepository(_context);
            LocalReviews = localReviews;
            ServiceReviews = serviceReviews;
            Trips = trips;
            
        }


        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
