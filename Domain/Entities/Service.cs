using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Service
    {
        public int Id { get; private set;}
        public string Name { get; private set;}

        public string Description { get; private set;}

        public DateTime WorkingHoursStart { get; private set;}
        public DateTime WorkingHoursEnd { get; private set;}
        public string phone { get; private set;}
        public string Adress { get; private set;}
        public virtual List<ServiceReview> Reviews { get; set; }

        List<string> ImageUrls { get; set; } = new();
    }
}
