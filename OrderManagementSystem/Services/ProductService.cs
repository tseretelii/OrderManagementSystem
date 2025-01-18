using OrderManagementSystem.Data;
using OrderManagementSystem.Data.DTOS.Product;
using OrderManagementSystem.Data.Models;

namespace OrderManagementSystem.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateProduct(ProductCreationDTO productDTO)
        {
            try
            {
                Product product = new Product()
                {
                    ProductName = productDTO.ProductName,
                    Description = productDTO.ProductDescription,
                    Price = productDTO.Price
                };

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
