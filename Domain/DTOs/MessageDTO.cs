using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class MessageDTO
    {
        public int Id { get;  set; }

        public string Content { get;  set; }

        public DateTime SendDate { get;  set; }

        public int SenderId { get;  set; }

        public int RecieverId { get;  set; }
    }
}
