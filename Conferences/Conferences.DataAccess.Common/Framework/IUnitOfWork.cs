using System;
using System.Threading.Tasks;
using Conferences.DataAccess.Common.Repositories;

namespace Conferences.DataAccess.Common.Framework
{
    public interface IUnitOfWork : IDisposable
    {
        IProductsRepository ProductsRepository { get;}

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task<int> CompleteAsync();
    }
}
