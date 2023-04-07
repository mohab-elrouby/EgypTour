using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository Posts { get; }

        public IGenericRepository<Tourist> _tourists { get;}
        IServiceRepository _services {get;}
        ILocalReviewRepository LocalReviews { get; }
        IServiceReviewRepository _serviceReviews { get; }      
        ITripRepository Trips { get;}
        public IGenericRepository<Activity> _activities { get; }
        public IGenericRepository<ToDoList> _toDoLists { get; }
        public IGenericRepository<ToDoItem> _toDoItems { get; }

        public IGenericRepository<LocalPerson> _localPersons { get; }
        int Commit();
    }
}
