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
        ICommentRepository Comment { get; }
        ILocalPersonRepository LocalPerson { get; }
        IActivityRepository Activity { get; }
        IMessageRepository Message { get; }
        IToDoItemRepository ToDoItem { get; }

        int Commit();
    }
}
