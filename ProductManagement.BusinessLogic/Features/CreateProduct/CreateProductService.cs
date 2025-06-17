using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProductManagement.BusinessLogic.Shared;
namespace ProductManagement.BusinessLogic.Features.CreateProduct
{
    public class CreateProductService
    {
        private readonly DapperService dapperService = new DapperService();
        public async Task<int> CreateProductAsync(CreateProductRequestmodel request)
        {
            string query = @"INSERT INTO Tbl_Products (Name, Price, Description, CreatedAt)
                                VALUES (@Name, @Price, @Description, @CreatedAt) ";

            var data = await dapperService.ExecuteAsync(query, new CreateProductRequestmodel
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            });

            return data;
        }
    }
}
