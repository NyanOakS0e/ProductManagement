using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.BusinessLogic.Features.GetProduct
{
    public class GetAllProductResponseModel:BaseResponseModel
    {
        public List<ProductModel> Products { get; set; } = new();
    }
}
