using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Post
    {
        public int Id { get; private set; }
        public virtual List<Image> Pictures { get; private set; } = new List<Image>();
        public DateTime DatePosted { get; private set; }
        public virtual List<Tourist> Likers { get; private set; } = new();
        public virtual List<Comment> Comments { get; private set; } = new();
        public int WriterId { get; private set; }
        public virtual Tourist Writer { get; private set; }
        public string Content { get; private set; }

        public Post( List<Image> pictures, DateTime datePosted, int writerId, string content)
        {
            Pictures=pictures;
            DatePosted=datePosted;
            WriterId=writerId;
            Content=content;
        }
        public Post() { }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }
        public void RemoveComment(Comment comment) 
        { 
            Comments.Remove(comment); 
        }
        public void AddLiker(Tourist tourist)
        {
            Likers.Add(tourist);
        }
        public void RemoveLiker(Tourist tourist)
        {
            Likers.Remove(tourist);
        }
        public void AddImage(string url)
        {
            var image = new Image(url);
            Pictures.Add(image);
        }
    }
}
