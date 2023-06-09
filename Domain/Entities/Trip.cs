﻿using Domain.DTOs;
using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Trip
    {
        public int Id { get; private set;}
        public string Name { get; private set; }

        public string Description { get; private set; }
        public DateTime? Start { get; private set; }

        public DateTime? End { get; private set; } 

        public Location? Location { get; private set; }
        public int OwnerId { get; private set; }
        public Tourist Owner { get; private set; }
        public string BackgroundImage { get; private set; }
        public float? Ypostion { get; private set; }
        public List<Image> images { get; private set; } = new();
        public virtual List<Activity> Activities { get; private set; } = new();
        public virtual List<ToDoList> ToDoLists { get; private set; } = new();
        public virtual List<Tourist> TripViewers { get; private set; } = new();
        public Trip(string name)
        {
            Name = name;
            Start = DateTime.Now;
            End = DateTime.MinValue;
        }
        public Trip(int ownerId, string name, DateTime? start, DateTime? end, Location? location, string backgroundImage= "", string description = "")
        {
            Name = name;
            Start = (start == null) ? DateTime.Now : start;
            End = (end == null) ? DateTime.MinValue : end;
            Location = (location == null) ? new Location(CityName.Cairo, Country.Egypt) : location;
            BackgroundImage = backgroundImage;
            Description = description;
            OwnerId = ownerId;
        }

        public void Update(TripDTO tripDTO)
        {
            ArgumentNullException.ThrowIfNull(tripDTO);
            Name = tripDTO.Name;
            Start = tripDTO.Start;
            End = tripDTO.End;
            Location = tripDTO.Location;
            BackgroundImage = tripDTO.BackgroundImage;
            Description = tripDTO.Description;
            Ypostion = tripDTO.Ypostion;

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

        public void AddImage(string imageParth)
        {
            Image image = new Image(imageParth);
            images.Add(image);
        }

        public void RemoveImage(string imagePath)
        {
            Image image = images.Where(i => i.Url == imagePath).FirstOrDefault();
            if (image == null)
            {
                throw new KeyNotFoundException($"Trip{Id} doesn't have such image");
            }
            else
            {
                images.Remove(image);
            }
            
        }
        public void AddToDoList(ToDOListDTO toDoList)
        {
            ToDoList _toDoList = new ToDoList(toDoList.Name);
            ToDoLists.Add(_toDoList);
        }
        private Trip()
        {
        }
    }
        

    
}
