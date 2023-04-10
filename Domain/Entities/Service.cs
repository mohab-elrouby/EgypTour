using Domain.DTOs;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Service
    {
        public int Id { get; private set;}
        public string Name { get; private set;}

        public string Description { get; private set;}
        public Location Location { get; private set;}

        public DateTime WorkingHoursStart { get; private set;}
        public DateTime WorkingHoursEnd { get; private set;}
        public string phone { get; private set;}


        public virtual List<ServiceReview> Reviews { get; private set; } = new();

        public string ProfileImage { get; private set;}
        public List<Image> Images { get; private set; } = new();

        public Service(string name, string description, DateTime workingHoursStart, DateTime workingHoursEnd, string phone, Location location,string profileImage="")
        {
            ProfileImage = profileImage;
            Name = name;
            Description = description;
            WorkingHoursStart = workingHoursStart;
            WorkingHoursEnd = workingHoursEnd;
            this.phone = phone;
            Location = location;
        }
        private Service() { }
        public void AddImage(string url)
        {
            Image image = new Image(url);
            Images.Add(image);
        }

        public void Addbulkimages(ICollection<Image> images)
        {
            if(images != null)
            {
                Images.AddRange(images);
            }
            else
            {
                throw new ArgumentException("images must not be null or empty collection");
            }
        }
        public void AddReview(string content , float rating , Tourist writer)
        {
            if(rating < 0 || rating > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(rating));
            }
            ServiceReview review = new ServiceReview(rating, writer,content);

            Reviews.Add(review);
        }
        public void Update(ServiceDTO serviceDTO)
        {
            ArgumentNullException.ThrowIfNull(serviceDTO);
            this.Name=serviceDTO.Name;
            this.Description=serviceDTO.Description;
            this.phone = serviceDTO.phone;
            this.Location = serviceDTO.Location;
            this.WorkingHoursEnd = serviceDTO.WorkingHoursEnd;
            this.WorkingHoursStart = serviceDTO.WorkingHoursStart;
        }

        public void UpdateProfileImage(string path)
        {
            ProfileImage = path;
        }
        public void RemoveImage(string imagePath)
        {
            Image image = Images.Where(i => i.Url == imagePath).FirstOrDefault();
            if (image == null)
            {
                throw new KeyNotFoundException($"Service {Id} doesn't have such image");
            }
            else
            {
                Images.Remove(image);
            }

        }

    }
}
