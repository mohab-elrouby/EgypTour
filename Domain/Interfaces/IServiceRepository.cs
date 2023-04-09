using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServiceRepository:IGenericRepository<Service>
    {
        IEnumerable<ServiceSearchDTO> Search(float rating, string searchString, CityName? city, int skip = 0, int take = 8);

    }
}
