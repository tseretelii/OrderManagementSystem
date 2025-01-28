
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Interfaces;
using OrderManagementSystem.Services;
using System.Text.Json.Serialization;

namespace OrderManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // Configure JSON serialization to handle cycles
                    options.JsonSerializerOptions.WriteIndented = true; // Optional: for easier debugging
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Register the UserService
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<IOrderService,OrderService>();
            builder.Services.AddScoped<StringUtilsService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
