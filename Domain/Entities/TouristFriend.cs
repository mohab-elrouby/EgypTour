using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TouristFriend
    {
        public int TouristId { get; set; }
        public virtual Tourist User { get; set; }

        public int FriendId { get; set; }
        public virtual User Friend { get; set; }

        public TouristFriend(int touristId, int friendId)
        {
            TouristId=touristId;
            FriendId=friendId;
        }
        public TouristFriend()
        {
        }
    }
}

