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


        public TimeOnly WorkingHoursStart { get; private set;}
        public TimeOnly WorkingHoursEnd { get; private set;}
        public string phone { get; private set;}
        public string Adress { get; private set;}


        public virtual List<ServiceReview> Reviews { get; private set; } = new();


        public List<Image> Images { get; private set; } = new();

        public Service(string name, string description, TimeOnly workingHoursStart, TimeOnly workingHoursEnd, string phone, string adress)
        {
            Name = name;
            Description = description;
            WorkingHoursStart = workingHoursStart;
            WorkingHoursEnd = workingHoursEnd;
            this.phone = phone;
            Adress = adress;
        }
        private Service() {}
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
        public void AddReview(ServiceReview review)
        {
            ArgumentNullException.ThrowIfNull(review);
            Reviews.Add(review);
        }
        public void Update(ServiceDTO serviceDTO)
        {
            ArgumentNullException.ThrowIfNull(serviceDTO);
            this.Name=serviceDTO.Name;
            this.Description=serviceDTO.Description;
            this.phone = serviceDTO.phone;
            this.Adress = serviceDTO.Adress;
            this.WorkingHoursEnd = serviceDTO.WorkingHoursEnd;
            this.WorkingHoursStart = serviceDTO.WorkingHoursStart;
        }
    }
}
