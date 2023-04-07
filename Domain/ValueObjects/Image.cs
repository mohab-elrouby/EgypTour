using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Image
    {
        public string Url { get;private set; }
        public Image(string url)
        {
            if(url == null) throw new ArgumentNullException("url");
            this.Url = url;
        }
    }
}
