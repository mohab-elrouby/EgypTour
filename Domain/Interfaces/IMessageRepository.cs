using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMessageRepository:IGenericRepository<Messege>
    {
        IEnumerable<Messege> GetBySenderId(int SenderId);
        IEnumerable<Messege> GetByReceiverId(int ReceiverId);

    }
}
