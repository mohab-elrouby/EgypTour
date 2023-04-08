using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EgyTourContext _context;
        public IPostRepository Posts { get; private set; }

        public IGenericRepository<Tourist> Tourists { get; private set; }
        public IGenericRepository<LocalPerson> LocalPersons { get; private set; }

        public IGenericRepository<TouristFriend> TouristFriends { get; private set; }

        public UnitOfWork(EgyTourContext context)
        {
            _context=context;
            Posts = new PostRepository(_context);
            Tourists = new GenericRepository<Tourist>(_context);
            LocalPersons = new GenericRepository<LocalPerson>(_context);
            TouristFriends = new GenericRepository<TouristFriend>(_context);
        }


        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
