using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SqlDataAccess
    {
        public async Task<List<T>> LoadDataAsync<T, U>(string sqlStatement, U parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = (await connection.QueryAsync<T>(sqlStatement, parameters)).ToList();
                return rows;
            }
        }
        public async void SaveData<T>(string sqlStatement, T parameters, string connectionString)
        {

            using(IDbConnection connection = new SqlConnection(connectionString))
            {
               await connection.ExecuteAsync(sqlStatement,parameters);
            }
        }
    }
}
