using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPostRepository:IGenericRepository<Post>
    {
        IEnumerable<Post> GetForFriends(List<int> friendsIds, int skip = 0, int take = 8);
    }
}
