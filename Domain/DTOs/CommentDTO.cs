using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public int WriterId { get; set; }

        public static CommentDTO FromEntity(Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                Content= comment.Content,
                Date = comment.Date,
                PostId = comment.PostId,
                WriterId = comment.WriterId
            };
        }
        public static Comment ToEntity(CommentDTO comment)
        {
            return new Comment(comment.Content, comment.Date, comment.PostId, comment.WriterId);
        }
    }
}
