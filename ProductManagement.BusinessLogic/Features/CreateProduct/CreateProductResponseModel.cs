using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.BusinessLogic.Features.CreateProduct
{
    public class CreateProductResponseModel:BaseResponseModel
    {
        public object Product { get; set; }
    }
}
