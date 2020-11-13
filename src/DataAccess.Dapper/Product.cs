using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Core;
using Core.DataAccess;

namespace DataAccess.Dapper
{
    public class Product : DapperDataAccessBase, IProduct
    {
        public Product(IDbConnection connection) : base(connection)
        {
        }

        public async Task<IEnumerable<Core.Entities.Product>> GetFeaturedProducts()
        {
            return await ProcedureAsync<Core.Entities.Product>(StoredProcedures.GetFeaturedProducts);
        }

        public async Task<IEnumerable<Core.Entities.Product>> GetProductsByCategoryId(int categoryId)
        {
            return await ProcedureAsync<Core.Entities.Product>(StoredProcedures.GetProductsByCategoryId, 
                new {
                    CategoryId = categoryId
                });
        }
    }
}
