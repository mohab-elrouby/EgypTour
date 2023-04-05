using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILocalReviewRepository:IGenericRepository<LocalReview>
    {
        public IEnumerable<LocalReview> GetByLocalPersonId(int id, int skip, int take);
    }
}
