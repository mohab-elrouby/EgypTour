using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public List<string> PictureIds { get; set; } = new List<string>();
        public DateTime DatePosted { get; set; }
        public List<int> LikersIds { get; set; } = new List<int>();
        public List<CommentDTO> Comments { get; set; } = new List<CommentDTO>();
        public int WriterId { get; set; }
        public string Content { get; set; }
        public static PostDTO FromEntity(Post post)
        {
            PostDTO dto = new PostDTO()
            {
                Id = post.Id,
                DatePosted = post.DatePosted,
                WriterId = post.WriterId,
                Content = post.Content
            };

            dto.Comments = post.Comments.Select(c => CommentDTO.FromEntity(c)).ToList();
            dto.PictureIds = post.Pictures.Select(p => p.Url).ToList();
            dto.LikersIds = post.Likers.Select(l => l.Id).ToList();
            return dto;
        }

        public static Post ToEntity(PostDTO postDto)
        {
            var post = new Post(new List<ValueObjects.Image>(), postDto.DatePosted, postDto.WriterId, postDto.Content);
            return post;
        }
    }
}
