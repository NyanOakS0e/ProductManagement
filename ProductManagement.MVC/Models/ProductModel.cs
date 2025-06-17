namespace ProductManagement.MVC.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }

    public class GetProductResponseModel
    {
        public List<ProductModel> products { get; set; }
        public string ResponseCode { get; set; }

        public string Message { get; set; }
    }
}
