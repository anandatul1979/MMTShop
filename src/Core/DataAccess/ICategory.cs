using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
