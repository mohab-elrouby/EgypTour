using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILocalPersonRepository:IGenericRepository<LocalPerson>
    {
        IEnumerable<LocalPerson> GetByPersonId(int Id);
        IEnumerable<LocalPerson> SearchByName(string name);
        IEnumerable<LocalPerson> SearchByLocation(string location);



    }
}
