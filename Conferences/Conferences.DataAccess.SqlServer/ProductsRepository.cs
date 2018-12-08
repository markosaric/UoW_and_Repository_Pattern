using Conferences.DataAccess.Common.Repositories;
using Conferences.DataAccess.Entities;

namespace Conferences.DataAccess.SqlServer
{
    public class ProductsRepository : Repository<Products>, IProductsRepository
    {
        public ProductsRepository(ConferencesDbContext context) : base(context)
        {
        }
    }
}
