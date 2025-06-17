using ProductManagement.BusinessLogic.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.BusinessLogic.Features.DeleteProduct
{
    public class DeleteProductService
    {
        private readonly DapperService dapperService = new DapperService();
        public Task<int> DeleteProductAsync(DeleteProductRequestModel reqModel)
        {
            
            string query = @"DELETE FROM Tbl_Products WHERE ProductId = @ProductId";
            var result =  dapperService.ExecuteAsync(query, reqModel );


            return result;
        }
    }
}
