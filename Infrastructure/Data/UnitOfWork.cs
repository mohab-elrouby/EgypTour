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
        public ICommentRepository Comment { get; private set; }
        public ILocalPersonRepository LocalPerson { get; private set; }

        public UnitOfWork(EgyTourContext context)
        {
            _context=context;
            Posts = new PostRepository(_context);
            Comment= new CommentRepository(_context);
            LocalPerson= new LocalPersonRepository(_context);   
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
