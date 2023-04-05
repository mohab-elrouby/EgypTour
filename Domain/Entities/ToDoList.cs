using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ToDoList
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public virtual List<ToDoItem> ToDoItems { get; private set; } = new();
        public int TripId { get; private set;}
        public virtual Trip Trip { get; private set;}
        public ToDoList(string name)
        {
            Name = name;
        }
        private ToDoList() { }

        public ToDoItemDTO AddToDoItem(ToDoItemDTO item)
        {
            return new ToDoItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                ToDoListId = item.ToDoListId,
                Status = item.Status,

            };
        }

    }
}
