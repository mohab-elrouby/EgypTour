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
        private List<string> notes;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public string Tag { get;private set; }
        public string Documents { get; private set; }

        public DateTime? Start { get; private set;}

        public DateTime? End { get; private set;}
        public int TripId { get; private set; }
        public virtual Trip Trip { get; private set; }
        public string? Location { get; private set; }

        public virtual List<Note> Notes { get; private set; }


        public Activity( string name, string description, string tag, string documents, DateTime? start, DateTime? end, int tripId, List<string> notes, string location)
        {
            Name=name;
            Description=description;
            Tag=tag;
            Documents=documents;
            Start=start;
            End=end;
            TripId=tripId;
            this.notes=notes;
            Location=location;
        }
        private Activity()
        {}
    }
}
