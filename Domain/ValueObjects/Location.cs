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
        public CityName CityName { get;private set; }

        public Country Country { get;private set; }

        public Location(CityName cityName, Country country)
        {
            CityName = cityName;
            Country = country;
        }
    }
}
