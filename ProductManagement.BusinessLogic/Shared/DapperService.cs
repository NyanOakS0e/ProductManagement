using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.BusinessLogic.Shared
{
    public class DapperService
    {
        private readonly string _connectionString = "Server=.;Database=Products;User Id=sa;Password=sasa@123;TrustServerCertificate=True;";


        public async Task<List<T>> QueryAsync<T>(string query, object? parameter = null)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            var lst = await dbConnection.QueryAsync<T>(query, parameter);
            var dataList = lst.ToList();

            return dataList;
        }

        public async Task<int> ExecuteAsync(string query, object parameter)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            var data = await dbConnection.ExecuteAsync(query, parameter);

            return data;
        }
    }
}
