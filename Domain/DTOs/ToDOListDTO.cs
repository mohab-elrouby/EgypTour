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
        public int Id { get;  set; }
        public string Name { get;  set; }
        //public List<ToDoItemDTO> Items { get; set; } = new();

        public static ToDOListDTO FromToDoList(ToDoList ToDoList) {
            return new ToDOListDTO
            {
                Id = ToDoList.Id,
                Name = ToDoList.Name,
                //Items = ToDoList.ToDoItems.Select(i => ToDoItemDTO.FromtoDoItem(i)).ToList()
            };
        }
    }
}
