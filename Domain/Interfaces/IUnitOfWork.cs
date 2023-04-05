using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }
        public IGenericRepository<Tourist> _tourists { get;}
        IServiceRepository _services {get;}
        public IGenericRepository<ServiceReview> _serviceReviews { get; }

        int Commit();
    }
}
