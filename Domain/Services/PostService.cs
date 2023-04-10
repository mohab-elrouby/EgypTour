using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class PostService : IPostService
    {
        IPostRepository postRepository { get; set; }
        IGenericRepository <TouristFriend> touristRepository { get; set; }

        public PostService(IPostRepository postRepository, IGenericRepository<TouristFriend> GenericRepository)
        {
            this.postRepository=postRepository;
            touristRepository=GenericRepository;
        }

        public IEnumerable<Post> GetForFriends(int userId, int skip = 0, int take = 8)
        {
            var friends = touristRepository.Find(f => f.TouristId == userId).Select(p => p.FriendId).ToList();
            return postRepository.GetForFriends(friends, skip:skip, take:take);
        }
    }
}
