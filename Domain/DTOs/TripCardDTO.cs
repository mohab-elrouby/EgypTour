using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class TripCardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackgroundImage { get; set; }

        public static TripCardDTO FromTrip(Trip trip)
        {
            return new TripCardDTO
            {
                Id = trip.Id,
                Name = trip.Name,
                BackgroundImage = trip.BackgroundImage,
            };


        }
    }
}
