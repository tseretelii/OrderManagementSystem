using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Data.DTOS;
using OrderManagementSystem.Data.DTOS.Order;
using OrderManagementSystem.Data.Models;
using OrderManagementSystem.Interfaces;
using OrderManagementSystem.Services;

namespace OrderManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService service)
        {
            _orderService = service;
        }

        [HttpPost]
        public async Task<bool> CreateOrder(OrderCreationDTO request)
        {
            return await _orderService.CreateOrder(request);
        }

        [HttpGet]
        public async Task<List<Order>> GetAllOrders()
        {
            return await _orderService.GetAllOrders();
        }

        [HttpGet("{id}")]
        public async Task<Order> GetOrder(int id)
        {
            return await _orderService.GetOrder(id);
        }

        [HttpGet("get-order-sum/{personId}")]
        public async Task<decimal> GetAllOrdersAmount(int personId)
        {
            return await _orderService.GetAllOrdersAmount(personId);
        }


        [HttpDelete("{id}")]
        public async Task<bool> DeleteOrder(int id)
        {
            return await _orderService.DeleteOrder(id);
        }
    }
}
