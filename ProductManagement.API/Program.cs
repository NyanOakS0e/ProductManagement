
using ProductManagement.BusinessLogic.Features.CreateProduct;
using ProductManagement.BusinessLogic.Features.DeleteProduct;
using ProductManagement.BusinessLogic.Features.GetProduct;
using ProductManagement.BusinessLogic.Features.UpdateProduct;

namespace ProductManagement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<CreateProductService>();
            builder.Services.AddScoped<GetAllProductService>();
            builder.Services.AddScoped<UpdateProductService>();
            builder.Services.AddScoped<DeleteProductService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
