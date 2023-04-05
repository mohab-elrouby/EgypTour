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

        public IGenericRepository<Tourist> _tourists { get; private set; }

        public IServiceRepository _services { get; private set; }

        public IGenericRepository<ServiceReview> _serviceReviews { get; private set; }

        public UnitOfWork(EgyTourContext context , IServiceRepository services ,
            IGenericRepository<Tourist> tourists ,IGenericRepository<ServiceReview> serviceReviews)
        {
            _context=context;
            Posts = new PostRepository(_context);
            _services = services;
            _tourists = tourists;
            _serviceReviews = serviceReviews;
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
