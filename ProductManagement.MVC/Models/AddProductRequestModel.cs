﻿namespace ProductManagement.MVC.Models
{
    public class AddProductRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
