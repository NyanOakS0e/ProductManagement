﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.BusinessLogic.Features.UpdateProduct
{
    public class UpdateProductResponseModel:BaseResponseModel
    {
       public ProductModel UpdatedPoduct { get; set; } = new ProductModel();
    }
}
