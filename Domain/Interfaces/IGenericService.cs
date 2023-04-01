using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICrudService<T> where T : class
    {
        public T Get(int id);
        public void Delete(int id);
        public void Update(T entity);
        
        public void Create(T entity);
    }
}
