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
        public int Id { get; private set; } = default(int);
        public string Name { get;  set; }

        public string Description { get;  set; }

        public DateTime WorkingHoursStart { get;  set; }
        public DateTime WorkingHoursEnd { get;  set; }
        public string phone { get;  set; }
        public Location Location { get; set; }
        public string ProfileImage { get; set; }
        public List<Image> Images { get; set; } = new();

        public static ServiceDTO FromService(Service service)
        {
            return new ServiceDTO()
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                WorkingHoursStart = service.WorkingHoursStart,
                WorkingHoursEnd = service.WorkingHoursEnd,
                phone = service.phone,
                Location = service.Location,
                ProfileImage= service.ProfileImage,
                Images = service.Images.ToList(),
            };
        }
    }
}
