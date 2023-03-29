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
        IEnumerable<Post> GetForSpecificUser(int userId);
        IEnumerable<Post> GetForFriends(int userId);
    }
}
