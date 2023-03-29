using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Messege
    {
        public int Id { get; private set; }
        
        public string Content { get; private set; }

        public DateTime SendDate { get; private set; }

        public int SenderId { get; private set; }
        public virtual User Sender { get; private set; }

        public int RecieverId { get; private set; }
        public virtual User Reciever { get; private set; }
        public Messege(string content,DateTime sendDate,User sender , User reciever) { 
            Sender = sender;
            Reciever = reciever;
            Content = content;
            SendDate = sendDate;        
        }
        private Messege() { }
    }
}
