using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public  class ActivityDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }

        public string Tag { get;  set; }

        public DateTime Start { get; set; } = DateTime.MinValue;

        public DateTime End { get; set; } = DateTime.MinValue;

        public int TripId { get;  set; }
        public string Location { get;  set; } = string.Empty;

        public virtual List<string> Notes { get;  set; }

        public static ActivityDTO FromActivity(Entities.Activity activity)
        {
            return new ActivityDTO
            {
                Id = activity.Id,
                Name = activity.Name,
                Description = activity.Description,
                Tag = activity.Tag,
                Start = activity.Start,
                End = activity.End,
                TripId = activity.TripId,
                Location = activity.Location,
                Notes = activity.Notes.Select(n=>n.Content).ToList(),

            };

        }
    }
}
