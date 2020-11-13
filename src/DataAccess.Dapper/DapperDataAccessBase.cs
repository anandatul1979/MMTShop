using Dapper;
using Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess.Dapper
{
    public abstract class DapperDataAccessBase
    {
        private readonly IDbConnection _connection;

        protected DapperDataAccessBase(IDbConnection connection)
        {
            _connection = connection;
        } 

        protected async Task<IEnumerable<T>> ProcedureAsync<T>(string name, object parameters = null)
        {
            try
            {
                _connection.Open();
                _connection.Execute($"USE {Environment.GetEnvironmentVariable(CommonVariables.DatabaseName)}");
                return await _connection.QueryAsync<T>(name, parameters, null, null, CommandType.StoredProcedure);
            }
            catch
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
