using Domain.DTOs;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tourist : User 
    {
        public Tourist(string fname, string lname, string email, string userName, string password, string phone, string profilePictureUrl = "")
    : base(fname, lname, email, userName, password, phone, profilePictureUrl){ }
        
        public virtual List<LocalReview> LocalReviews { get; private set; } = new();
        public virtual List<ServiceReview> ServiceReviews { get; private set; } = new();
        public List<TouristFriend> Friends { get; private set; } = new();
        public virtual List<Post> WrittenPosts { get; private set; } = new();
        public virtual List<Post> LikedPosts { get; private set; } = new();
        public virtual List<Comment> Comments { get; private set; } = new();
        public virtual List<Trip> Trips { get; private set; } = new();
        public virtual List<Trip> OwnedTrips { get; private set; } = new();
        public Tourist(string fname, string lname, string email, string usernameName, string password, string profilePictureUrl, string city, string phone)
            :base(fname, lname, email, usernameName, password, profilePictureUrl, phone)
        {
        }
        public Tourist()
        {
        }

        public void AddFriend(TouristFriend t)
        {
            Friends.Add(t);
        }
        public void DeleteFriend(TouristFriend t)
        {
            Friends.Remove(t);
        }


    }
}
