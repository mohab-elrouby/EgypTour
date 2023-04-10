using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ToDOListDTO
    {
        public int Id { get; private set; }
        public string Name { get;  set; }

        public static ToDOListDTO FromToDoList(ToDoList ToDoList) {
            return new ToDOListDTO
            {
                Id = ToDoList.Id,
                Name = ToDoList.Name,
            };
        }
    }
}
