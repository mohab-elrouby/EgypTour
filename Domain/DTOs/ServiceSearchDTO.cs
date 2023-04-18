using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ServiceSearchDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int MatchHeurstic { get; set; } = 0;

        public float AvgRating { get; set; }

        public string ProfileImage { get;set; }
        public string FirstReview { get; set; }
        public DateTime WorkingHoursStart { get; set; }
        public DateTime WorkingHoursEnd { get; set; }

        public static ServiceSearchDTO FromService(Service service, string searchString="" ,string matchString = "",float avgRating=0 , string firstReview="")
        {
            return new ServiceSearchDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                MatchHeurstic = LevenshteinDistance.Calculate(matchString, searchString),
                AvgRating = avgRating,
                ProfileImage = service.ProfileImage,
                FirstReview = firstReview,
                WorkingHoursStart = service.WorkingHoursStart,
                WorkingHoursEnd = service.WorkingHoursEnd,
            };
        }
    }
}
