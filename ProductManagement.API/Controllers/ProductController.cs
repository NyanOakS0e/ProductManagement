using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.BusinessLogic.Features;
using ProductManagement.BusinessLogic.Features.CreateProduct;
using ProductManagement.BusinessLogic.Features.DeleteProduct;
using ProductManagement.BusinessLogic.Features.GetProduct;
using ProductManagement.BusinessLogic.Features.UpdateProduct;
using ProductManagement.BusinessLogic.Shared;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class ProductController : ControllerBase
    {
        private readonly CreateProductService createProductService;
        private readonly GetAllProductService _getAllProductService;
        private readonly UpdateProductService _updateProductService;
        private readonly DeleteProductService _deleteProductService;
        public ProductController(CreateProductService createProductService, GetAllProductService getAllProductService, UpdateProductService updateProductService, DeleteProductService deleteProductService)
        {
            this.createProductService = createProductService;
            _getAllProductService = getAllProductService;
            _updateProductService = updateProductService;
            _deleteProductService = deleteProductService;
        }

        #region Create Product
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateProductControllerAsync([FromBody] CreateProductRequestmodel reqModel)
        {

            try
            {
                var result = await createProductService.CreateProductAsync(reqModel);

                if (result > 0)
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

        #endregion


        #region Get All Products
        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {

            try
            {
                var products = await _getAllProductService.GetAllProductsAsync();

                if (products.Products == null || !products.Products.Any())
                {
                    return NotFound(new { Message = "No products found" });
                }

                return Ok(new GetAllProductResponseModel
                {
                    Message = "Success",
                    Products = products.Products,
                    ResponseCode = "200"

                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        #endregion


        #region Update Product


        [HttpPost]

        [Route("Update")]

        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductRequestModel reqModel)
        {
            try
            {
                var result = await _updateProductService.UpdateProduct(reqModel);

                if (result <= 0)
                {
                    return BadRequest(new UpdateProductResponseModel
                    {
                        UpdatedPoduct = null,
                        Message = "Failed to update product",
                        ResponseCode = "400"
                    });
                }

                return Ok(new UpdateProductResponseModel
                {
                    UpdatedPoduct = new ProductModel
                    {
                        ProductId = reqModel.ProductId,
                        Name = reqModel.Name,
                        Description = reqModel.Description,
                        Price = reqModel.Price,
                        UpdatedAt = reqModel.UpdatedAt
                    },
                    Message = "Product updated successfully",
                    ResponseCode = "200"
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.ToString()}");
            }



        }
        #endregion


        #region Delete Product
        [HttpPost]
        [Route("Delete")]

        public async Task<IActionResult> DeleteProductAsync([FromBody] DeleteProductRequestModel reqModel)
        {

        

            try
            {
                var result = await _deleteProductService.DeleteProductAsync(reqModel);

                if (result <= 0)
                {
                    return BadRequest(new DeleteProductResponseModel
                    {
                        Message = "Failed to delete product",
                        ResponseCode = "400",
                    });
                }

                return Ok(new DeleteProductResponseModel
                {
                    Message = "Product delete successful",
                    ResponseCode = "200",
                });

            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.ToString()}");
            }
           

        }
        #endregion
    }
}
