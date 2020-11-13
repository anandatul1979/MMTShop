using Core;
using Core.DataAccess;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.Dapper
{
    public class Category : DapperDataAccessBase, ICategory
    {
        public Category(IDbConnection connection) : base(connection)
        {
        }

        public async Task<IEnumerable<Core.Entities.Category>> GetAllAsync()
        {
            return await ProcedureAsync<Core.Entities.Category>(StoredProcedures.GetCategories);
        }
    }
}
