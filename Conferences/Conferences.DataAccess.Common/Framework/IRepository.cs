using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Conferences.DataAccess.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(object id);

        Task<IEnumerable<TEntity>> GetAsync();

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
