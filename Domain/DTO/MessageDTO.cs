using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class MessageDTO
    {
        public int Id { get; private set; }

        public string Content { get; private set; }

        public DateTime SendDate { get; private set; }

        public int SenderId { get; private set; }

        public int RecieverId { get; private set; }
    }
}
