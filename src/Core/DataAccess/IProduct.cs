using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface IProduct
    {
        Task<IEnumerable<Product>> GetFeaturedProducts();

        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
    }
}
