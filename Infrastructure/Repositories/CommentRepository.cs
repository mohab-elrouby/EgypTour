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
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly EgyTourContext _db;
        public CommentRepository(EgyTourContext db) : base(db)
        {
            _db= db;
        }
<<<<<<< HEAD
        public IEnumerable<Comment> GetByPostsId(int postId)
        {
            return _db.Comments.Where(c => c.PostId== postId);
        }
=======
<<<<<<< HEAD
        public IEnumerable<Comment> GetByPostsId(int postId)
        {
            return _db.Comments.Where(c=>c.PostId== postId);
        }
=======
>>>>>>> 2277183994b950702e569ad351db5696bddfa6b9
>>>>>>> d729ee470768fc1dfb37a57a39de6ea21ab7ed7a
    }
}
