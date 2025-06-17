using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.BusinessLogic.Features.UpdateProduct
{
    public class UpdateProductRequestModel
    {
        public int ProductId { get; set; }

        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public decimal? Price { get; set; } 

        public DateTime UpdatedAt { get; set; }
    }
}
