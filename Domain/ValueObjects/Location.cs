using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Location
    {
        public CityName CityName { get; set; }

        public string Street { get; set; }

        public Location(CityName cityName, string street)
        {
            CityName = cityName;
            Street = street;
        }
    }
}
