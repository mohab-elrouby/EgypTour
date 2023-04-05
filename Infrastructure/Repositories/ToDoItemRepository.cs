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
    public class ToDoItemRepository : GenericRepository<ToDoItem>, IToDoItemRepository
    {
        private readonly EgyTourContext _db;
        public ToDoItemRepository(EgyTourContext db) : base(db)
        {
            _db= db;
        }

        public IEnumerable<ToDoItem> GetByToDoListId(int ToDoListId)
        {
           return _db.ToDoItems.Where(x => x.ToDoListId == ToDoListId);
        }
    }
}
