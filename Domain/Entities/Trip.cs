using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Trip
    {
        public int Id { get; private set;}
        public string Name { get; private set; }

        public DateTime? Start { get; private set; }

        public DateTime? End { get; private set; } 

        public string? Location { get; private set; }

        public virtual List<Activity> Activities { get; private set; } = new();
        public virtual List<ToDoList> ToDoLists { get; private set; } = new();
        public virtual List<Tourist> Tourists { get; private set; } = new();
        public Trip(string name)
        {
            Name = name;
            Start = DateTime.Now;
            End = DateTime.MinValue;
        }
        public Trip(string name, DateTime? start, DateTime? end, string? location)
        {
           Name=name;
           Start = (start == null) ? DateTime.Now : start;
           End = (end == null) ? DateTime.MinValue : end;
           Location = location;
        }

        private Trip() { 
        }

    }
}
