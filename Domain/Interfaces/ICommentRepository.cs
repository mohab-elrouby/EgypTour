using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICommentRepository:IGenericRepository<Comment>
    {
<<<<<<< HEAD
        IEnumerable<Comment> GetByPostsId(int postId);
=======
>>>>>>> 2277183994b950702e569ad351db5696bddfa6b9
    }
}
