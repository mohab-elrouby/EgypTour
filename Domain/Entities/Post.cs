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
        public virtual List<Image> Pictures { get; private set; }
        public DateTime DatePosted { get; private set; }

        public virtual List<Tourist> Likers { get; private set; } = new();
        public virtual List<Comment> Comments { get; private set; } = new();
        public int WriterId { get; private set; }
        public virtual Tourist Writer { get; private set; }
        public string Content { get; private set; }  
        
        

    }
}
