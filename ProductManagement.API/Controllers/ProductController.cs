using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.BusinessLogic.Features.CreateProduct;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class ProductController : ControllerBase
    {
        private readonly CreateProductService createProductService;

        public ProductController(CreateProductService createProductService)
        {
            this.createProductService = createProductService;
        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProductControllerAsync([FromBody] CreateProductRequestmodel reqModel)
        {

            try
            {
                var result = await createProductService.CreateProductAsync(reqModel);

                if(result > 0)
                {
                    return Ok(new CreateProductResponseModel
                    {
                        Message = "Product created successfully",
                        ResponseCode = "200",
                        Product = new
                        {
                            Name = reqModel.Name,
                            Description = reqModel.Description,
                            Price = reqModel.Price,
                            CreatedAt = reqModel.CreatedAt
                        }
                    });
                }

                return BadRequest(new CreateProductResponseModel
                {
                    Message = "Failed to create product",
                    ResponseCode = "400"
                });
            } 
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.ToString()}");
            }
           
        }
    }
}
