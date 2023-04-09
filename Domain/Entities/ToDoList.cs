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
            Name = (name == null) ? string.Empty : name;
        }
        private ToDoList() { }

        public void Update(ToDOListDTO toDOListDTO)
        {
            Name = toDOListDTO.Name;
        }

        public void AddToDoItem(ToDoItemDTO toDOItemDTO)
        {
            ToDoItem toDoItem = new ToDoItem(toDOItemDTO.Name , toDOItemDTO.Status);
            ToDoItems.Add(toDoItem);
        }
    }
}
