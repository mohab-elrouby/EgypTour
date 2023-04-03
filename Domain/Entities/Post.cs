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
        public int Id { get; set; }
        public virtual List<Image> Pictures { get; set; }
        public DateTime DatePosted { get; set; }

        public virtual List<Tourist> Likers { get; set; } = new();
        public virtual List<Comment> Comments { get; set; } = new();
        public int WriterId { get; set; }
        public virtual Tourist Writer { get; set; }
        public string Content { get; set; }  
        
        

    }
}
