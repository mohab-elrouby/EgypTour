using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class TouristDTO
    {
        public int Id { get; set; }
        public string Fname { get; set; } = "";
        public string Lname { get; set; } = "";
        
        public string? ProfilePicUrl { get; set; }

        public static TouristDTO FromTourist(Tourist tourist)
        {
            return new TouristDTO
            {
                Id = tourist.Id,
                Fname = tourist.Fname,
                Lname = tourist.Lname,
                ProfilePicUrl = tourist.ProfilePictureUrl,
            };
        }
    }
}
