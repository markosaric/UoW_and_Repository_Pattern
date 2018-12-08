using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Conferences.DataAccess.Common;
using Conferences.DataAccess.Common.Framework;
using Conferences.DataAccess.Common.Repositories;
using Conferences.DataAccess.SqlServer;
using Microsoft.Extensions.Configuration;

namespace Conferences.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConferencesDbContext _context;
        private readonly Dictionary<string, object> _repositories;

        private IProductsRepository _productsRepository = null;
        public IProductsRepository ProductsRepository => this._productsRepository ?? (this._productsRepository = new ProductsRepository(_context));

        public UnitOfWork(IConfiguration configuration)
        {
            _context = new ConferencesDbContext(configuration);
            _repositories = new Dictionary<string, object>();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var name = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(name))
            {
                var repo = (IRepository<TEntity>)this.GetType().GetProperties()
                    .First(x =>
                        x.PropertyType.GetInterfaces().Any(y =>
                            y.GetGenericArguments().Any(z =>
                                z == typeof(TEntity))))
                    .GetValue(this);

                _repositories.Add(name, repo);
            }

            return (IRepository<TEntity>)_repositories[name];
        }
    }
}
