using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ToDoItemDTO
    {
        public int Id { get;  set; }

        public string Name { get;  set; }

        public ToDoItemStatus Status { get;  set; }
        public static ToDoItemDTO FromtoDoItem(ToDoItem ToDoItem) {
            return new ToDoItemDTO
            {
                Id = ToDoItem.Id,
                Name = ToDoItem.Name,
                Status = ToDoItem.Status
            };
        }
    }
}
