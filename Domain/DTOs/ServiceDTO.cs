using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set;}
        public string Name { get;  set; }

        public string Description { get;  set; }

        public TimeOnly WorkingHoursStart { get;  set; }
        public TimeOnly WorkingHoursEnd { get;  set; }
        public string phone { get;  set; }
        public string Adress { get; set; }


        public virtual List<ReviewDto> Reviews { get; set; } = new();

        public List<Image> Images { get; set; } = new();

        public static ServiceDTO FromService(Service service)
        {
            ArgumentNullException.ThrowIfNull(service);
            return new ServiceDTO()
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                WorkingHoursStart = service.WorkingHoursStart,
                WorkingHoursEnd = service.WorkingHoursEnd,
                phone = service.phone,
                Adress = service.Adress,
                Images = service.Images.ToList(),
                Reviews = service.Reviews.Select(r => ReviewDto.FromReview(r)).ToList()               
            };
        }
    }
}
