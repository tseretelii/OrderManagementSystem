using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Data.DTOS.Product;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService service)
        {
            _productService = service;
        }

        [HttpPost]
        public async Task<bool> CreateProduct(ProductCreationDTO request)
        {
            return await _productService.CreateProduct(request);
        }
    }
}
