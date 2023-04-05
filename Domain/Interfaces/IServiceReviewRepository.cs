using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServiceReviewRepository: IGenericRepository<ServiceReview>
    {
        public IEnumerable<ServiceReview> GetByTouristId(int id, int skip, int take);
        public IEnumerable<ServiceReview> GetByServiceId(int id, int skip, int take);
    }
}
