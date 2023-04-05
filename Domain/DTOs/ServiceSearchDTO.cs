using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ServiceSearchDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int MatchHeurstic { get; set; }

        public float AvgRating { get; set; }

        public static ServiceSearchDTO FromService(Service service,string searchString ,string matchString,float avgRating)
        {
            return new ServiceSearchDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                MatchHeurstic = LevenshteinDistance.Calculate(matchString, searchString),
                AvgRating = avgRating
            };
        }
    }
}
