using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class RecommendationsDto
    {
        public List<ServiceRecommendationDTO> serviceRecommendations { get; set; }
        public List<LocalPersonRecommendationDTO> localPersonRecommendations { get; set; }
    }
}
