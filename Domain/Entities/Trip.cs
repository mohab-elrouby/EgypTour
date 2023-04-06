using Domain.DTOs;
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
        public Tourist Owner { get; private set; }
        public string BackgroundImage { get; set; }
        public virtual List<Activity> Activities { get; private set; } = new();
        public virtual List<ToDoList> ToDoLists { get; private set; } = new();
        public virtual List<Tourist> TripViewers { get; private set; } = new();
        public Trip(string name)
        {
            Name = name;
            Start = DateTime.Now;
            End = DateTime.MinValue;
        }
        public Trip(string name, DateTime? start, DateTime? end, string? location, string backgroundImage="")
        {
           Name=name;
           Start = (start == null) ? DateTime.Now : start;
           End = (end == null) ? DateTime.MinValue : end;
           Location = location;
            BackgroundImage = backgroundImage;
        }

        public void Update(string? name , string?location,string backgroundImage,DateTime start , DateTime end)
        {
            Name = name;
            Location = location;
            BackgroundImage = backgroundImage;
            Start = start;
            End = end;
        }

        public void AddTourist(Tourist tourist)
        {
            
            TripViewers.Add(tourist);
         
        }


        public void AddActivity(ActivityDTO activity)
        {
            Activity _activity = new Activity(activity.Name, activity.Location, activity.Start, activity.End
                ,activity.Notes,activity.Description,activity.Tag
                );
            Activities.Add(_activity);
        }
        public void AddToDoList(ToDOListDTO toDoList)
        {
            ToDoList _toDoList = new ToDoList(toDoList.Name);
        }
        private Trip()
        {
        }
    }
        

    
}
