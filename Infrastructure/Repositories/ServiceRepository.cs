﻿using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ServiceRepository:GenericRepository<Service>,IServiceRepository
    {
        public ServiceRepository(EgyTourContext context) : base(context) { }


        public IEnumerable<ServiceSearchDTO> Search(float rating,string searchString, CityName? city, int skip = 0, int take = 8)
        {
            IEnumerable<ServiceSearchDTO> result = _context.Services.Where(i => ((LevenshteinDistance.Calculate(searchString, i.Name) < 5 ||
            i.Name.Contains(searchString)) ||
            i.Description.Contains(searchString) ) &&
            i.Reviews.Average(r => r.Rating) > rating &&
            i.Location.CityName == city).OrderByDescending(i=>i.Reviews.Average(i=>i.Rating))
            .ThenBy(i => (LevenshteinDistance.Calculate(searchString, i.Name)))
            .Skip(skip).Take(take).Select(i => ServiceSearchDTO.FromService(i, searchString , i.Name, i.Reviews.Average(i => i.Rating)));
            return result;
        }
    }
}
