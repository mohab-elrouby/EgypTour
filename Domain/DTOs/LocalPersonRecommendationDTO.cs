using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class LocalPersonRecommendationDTO
    {
        public int Id { get; private set;}
        public string Fname { get;  set; }

        public float AveregeRating { get; set; }
        public string Lname { get;  set; }
        public string ProfilePictureUrl { get; set; }

        public static LocalPersonRecommendationDTO FromLocalPerson(LocalPerson localPerson,float avgRating)
        {
            LocalPersonRecommendationDTO localPersonRecommendationDto = new LocalPersonRecommendationDTO()
            {
                Id = localPerson.Id,
                Fname = localPerson.Fname,
                Lname = localPerson.Lname,
                AveregeRating = avgRating,
                ProfilePictureUrl = localPerson.ProfilePictureUrl
            };
            return localPersonRecommendationDto;
        }

    }
}
