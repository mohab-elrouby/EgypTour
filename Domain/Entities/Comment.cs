using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime? Date { get; set; }

        public int PostId { get;  set; }
        public virtual Post Post { get;  set; }
        public int? WriterId { get;  set; }
        public virtual Tourist Writer { get;  set; }
=======
        public int Id { get; private set; }
        public string Content { get; private set; }
        public DateTime? Date { get; private set; }

        public int? PostId { get;  set; }
        public virtual Post Post { get; private set; }
        public int? WriterId { get;  set; }
        public virtual Tourist Writer { get; private set; }
>>>>>>> 2277183994b950702e569ad351db5696bddfa6b9
    }
}
