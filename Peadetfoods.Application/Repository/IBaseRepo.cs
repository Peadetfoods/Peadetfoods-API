using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peadetfoods.Application.Repository
{
    public interface IBaseRepo<T> where T : class
    {
        IQueryable<T> Items { get; }

        void Add(T entity);
        Task<T> FindAsync(params object[] id);
        Task<T> GetFirstAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        void Remove(T entity);
        void Update(T entity);
    }
}
