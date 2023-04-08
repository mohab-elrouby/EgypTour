using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string UsernameName { get; set; }
        public string Password { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public static UserDTO FromEntity(User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                City= user.City,
                Phone= user.Phone,
                Email= user.Email,
                Fname = user.Fname,
                Lname = user.Lname, 
                Password= user.Password,
                ProfilePictureUrl= user.ProfilePictureUrl,
                UsernameName = user.UsernameName
            };
        }

        public static Tourist ToTourist(UserDTO user)
        {
            return new Tourist(user.Fname, user.Lname, user.Email, user.UsernameName, user.Password, user.ProfilePictureUrl, user.City, user.Phone);
        }
    }
}
