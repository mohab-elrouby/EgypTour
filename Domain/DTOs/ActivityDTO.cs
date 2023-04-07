using Domain.ValueObjects;
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
        public int Id { get; private set; } = default(int);
        public string Name { get;  set; }
        public string Description { get; set; } = string.Empty;

        public string Tag { get; set; } = string.Empty;

        public DateTime Start { get; set; } = DateTime.MinValue;

        public DateTime End { get; set; } = DateTime.MinValue;
        public Location? Location { get; set; } 

        public  List<Note> Notes { get; set; } = new();

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
                Location = activity.Location,
                Notes = activity.Notes,
            };

        }
    }
}
