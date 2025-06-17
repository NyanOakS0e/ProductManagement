using ProductManagement.BusinessLogic.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.BusinessLogic.Features.UpdateProduct
{
    public class UpdateProductService
    {
        private readonly DapperService _dapperService = new DapperService();

        public async Task<int> UpdateProduct(UpdateProductRequestModel reqModel)
        {
            string query = @"UPDATE Tbl_Products
                            SET 
                                Name = CASE WHEN @Name IS NOT NULL THEN @Name ELSE Name END,
                                Description = CASE WHEN @Description IS NOT NULL THEN @Description ELSE Description END,
                                Price = CASE WHEN @Price IS NOT NULL THEN @Price ELSE Price END,
                                UpdatedAt = @UpdatedAt
                            WHERE ProductId = @ProductId;
                            ";

            var result = await _dapperService.ExecuteAsync(query, new UpdateProductRequestModel
            {
                ProductId = reqModel.ProductId,
                Name = reqModel.Name,
                Description = reqModel.Description,
                Price = reqModel.Price,
                UpdatedAt = DateTime.UtcNow
            });

            return result;

        }
    }
}
