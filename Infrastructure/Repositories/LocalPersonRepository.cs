using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LocalPersonRepository : GenericRepository<LocalPerson>,ILocalPersonRepository
    {
        private readonly EgyTourContext _db;
        public LocalPersonRepository(EgyTourContext db) : base(db)
        {
            _db= db;
        }

        public IEnumerable<LocalPerson> GetByPersonId(int Id)
        {
            return _db.LocalPersons.Where(x => x.Id == Id); 
        }

        public IEnumerable<LocalPerson> SearchByLocation(string location)
        {
            return _db.LocalPersons.Where(x => x.City==location);
        }

        public IEnumerable<LocalPerson> SearchByName(string name)
        {
            return _db.LocalPersons.Where(p => p.Fname.Contains(name )||p.Lname.Contains(name)).ToList();
        }

     
    }
}
