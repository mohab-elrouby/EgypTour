using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class CommentDTO
    {
        public int Id { get;  set; }
        public string Content { get;  set; }
        public DateTime Date { get; set; }
        public int PostId { get; set; }
        public int WriterId { get;  set; }
    }
}
