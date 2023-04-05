using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tourist : User 
    {
        public virtual List<LocalReview> LocalReviews { get; private set; } = new();
        public virtual List<ServiceReview> ServiceReviews { get; private set; } = new();
        public List<Tourist> Friends { get; private set; } = new();
        public virtual List<Post> WrittenPosts { get; private set; } = new();
        public virtual List<Post> LikedPosts { get; private set; } = new();
        public virtual List<Comment> Comments { get; private set; } = new();
        public virtual List<Trip> Trips { get; private set; } = new();
        public Tourist(string fname, string lname, string email, string usernameName,
         string password, string city, string phone, string profilePictureUrl) : base(fname, lname, email,
             usernameName, password, city, phone, profilePictureUrl)
        { }
    }
}
