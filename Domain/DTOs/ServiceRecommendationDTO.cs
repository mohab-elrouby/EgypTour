using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ServiceRecommendationDTO
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public float AvgRating { get; set; }

        public static ServiceRecommendationDTO FromService(Service service, float avgRating)
        {
            return new ServiceRecommendationDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                AvgRating = avgRating
            };
        }
    }
}
