using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment
    {
        public int Id { get; private set; }
        public string Content { get; private set; }
        public DateTime? Date { get; private set; }

        public int? PostId { get;  set; }
        public virtual Post Post { get; private set; }
        public int? WriterId { get;  set; }
        public virtual Tourist Writer { get; private set; }
    }
}
