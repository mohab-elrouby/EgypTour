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
            else if(url.Length == 0)
            {
                throw new ArgumentException("Url Can not be null");
            }
            this.Url = url;
        }
    }
}
