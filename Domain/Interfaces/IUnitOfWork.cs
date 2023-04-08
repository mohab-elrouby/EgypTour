using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IPostRepository Posts { get; }
        IGenericRepository<Tourist> Tourists { get; }
        IGenericRepository<LocalPerson> LocalPersons { get; }
        IGenericRepository<TouristFriend> TouristFriends { get; }

        int Commit();
    }
}
