using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Post> GetForFriends(List<int> friendsId, int skip = 0, int take = 8)
        {
            return _context.Posts.Where(p => friendsId.Contains(p.WriterId))
                .Skip(skip).Take(take).Include(p => p.Comments).Include(p=>p.Pictures)
                .Include(p=>p.Likers).Include(p=>p.Writer).ToList();
        }
    }
}
