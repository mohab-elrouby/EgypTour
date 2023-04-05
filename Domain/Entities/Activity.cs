using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Activity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public string Tag { get;private set; }
       

        public DateTime Start { get; private set;}

        public DateTime End { get; private set;}
        public int TripId { get; private set; }
        public virtual Trip Trip { get; private set; }
        public string? Location { get; private set; }

        public virtual List<Note> Notes { get; private set; }

        public Activity(string name ,string location , DateTime start, DateTime end) { 
            Name = name;
            Location = location;
            Start= start;
            End= end;
        }
    }
}
