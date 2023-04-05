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
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {

        public PostRepository(EgyTourContext context):base(context) { }

        public IEnumerable<Post> GetForFriends(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetForSpecificUser(int userId)
        {
            return _context.Posts.Select(p => p).Where(p => p.WriterId == userId).ToList();
        }
    }
}
