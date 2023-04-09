using Domain.DTOs;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ToDoItem
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int ToDoListId { get; private set; }
        public virtual ToDoList ToDoList { get; private set; }
        public ToDoItemStatus Status { get; private set; }

        public ToDoItem(string name, ToDoItemStatus status)
        {
            Name = (name == null) ? string.Empty : name;
            Status = status;
        }
        public void UpdateName(string name)
        {
            Name =name;
        }
        public void MarkDone()
        {
            Status=ToDoItemStatus.Checked;
        }
        public void MarkNotDone()
        {
            Status=ToDoItemStatus.NotChecked;
        }
    }
}
