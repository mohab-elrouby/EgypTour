using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ToDoItemDTO
    {
        public int Id { get;  set; }

        public string Name { get;  set; }

        public int ToDoListId { get;  set; }
      
        public ToDoItemStatus Status { get;  set; }
    }
}
