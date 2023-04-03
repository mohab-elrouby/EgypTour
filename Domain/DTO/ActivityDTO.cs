using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ActivityDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public string Tag { get; private set; }
        public string Documents { get; private set; }

        public DateTime? Start { get; private set; }

        public DateTime? End { get; private set; }
        public int TripId { get; private set; }
        public string? Location { get; private set; }

        public virtual List<string> Notes { get; private set; }
    }
}
