using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Peadetfoods.Application.Repository;
using Peadetfoods.Infrastructure.Common.Database;

namespace Peadetfoods.Infrastructure.Repositories
{
    internal class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private readonly MainContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepo(MainContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> Items => _dbSet;

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual async Task<T> FindAsync(params object[] id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
    }
}
