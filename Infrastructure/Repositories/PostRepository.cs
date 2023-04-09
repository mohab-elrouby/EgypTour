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

        public IEnumerable<Post> GetForFriends(List<int> friendsId)
        {
            return _context.Posts.Where(p => friendsId.Contains(p.WriterId)).ToList();
            throw new NotImplementedException();
        }
    }
}
