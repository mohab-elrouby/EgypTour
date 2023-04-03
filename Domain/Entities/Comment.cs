using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }
        public int PostId { get;  set; }
        public virtual Post Post { get;  set; }
        public int? WriterId { get;  set; }
        public virtual Tourist Writer { get;  set; }

    }
}
