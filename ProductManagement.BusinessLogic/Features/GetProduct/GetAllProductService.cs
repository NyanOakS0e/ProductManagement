using ProductManagement.BusinessLogic.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.BusinessLogic.Features.GetProduct
{
    public class GetAllProductService
    {
        private readonly DapperService _dapperService = new DapperService();


        public async Task<GetAllProductResponseModel> GetAllProductsAsync()
        {
            string query = "SELECT * FROM Tbl_Products";

            var products = await _dapperService.QueryAsync<ProductModel>(query);

            return new GetAllProductResponseModel
            {
                Products = products.ToList()
            };
        }
    }
}
