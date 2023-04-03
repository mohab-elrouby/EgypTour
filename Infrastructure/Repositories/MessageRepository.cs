using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MessageRepository : GenericRepository<Messege>, IMessageRepository
    {
        private readonly EgyTourContext _db;
        public MessageRepository(EgyTourContext db) : base(db)
        {
            _db= db;
        }

        public IEnumerable<Messege> GetBySenderId(int SenderId)
        {
            return _db.Messeges.Where(e => e.SenderId == SenderId);
        }
        public IEnumerable<Messege> GetByReceiverId(int ReceiverId)
        {
            return _db.Messeges.Where(e => e.RecieverId == ReceiverId);
        }
    }
}
