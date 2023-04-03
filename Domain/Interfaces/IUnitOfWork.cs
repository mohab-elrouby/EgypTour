using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IPostRepository Posts { get; }
        ILocalReviewRepository LocalReviews { get; }
        IServiceReviewRepository ServiceReviews { get; }
      
         //IGenericRepository<LocalPerson> LocalPersons { get;}
        int Commit();
    }
}
