using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        T Add(T entity);
        Task<T> AddAsync(T entity);

        IEnumerable<T> GetAll();
        Task<T> Delete(int id);
        T Update(T entity);
    }
}
