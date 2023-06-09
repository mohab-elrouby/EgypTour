﻿using Domain.DTOs;
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
        public string? Description { get; private set; }

        public string? Tag { get;private set; } 
       

        public DateTime Start { get; private set;}

        public DateTime End { get; private set;}
        public int TripId { get; private set; }
        public virtual Trip Trip { get; private set; }
        public Location? Location { get; private set; }

        public virtual List<Note>? Notes { get; private set; }

        public Activity(string name ,Location location , DateTime start, DateTime end ,List<Note> notes,string description
            ,string tag)
        { 
            Name = name;
            Location = location;
            Start= start;
            End= end;
            Notes = notes;
            Description = description;
            Tag = tag;            
        }
        public void Update (ActivityDTO activityDTO)
        {
            Name = activityDTO.Name;
            Location = activityDTO.Location;
            Start = activityDTO.Start;
            End = activityDTO.End;
            Description = activityDTO.Description;
            Tag = activityDTO.Tag;
            Notes = activityDTO.Notes;
        }
        private Activity() { }
    }
}
