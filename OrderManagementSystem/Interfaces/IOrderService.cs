using OrderManagementSystem.Data.DTOS.Order;
using OrderManagementSystem.Data.Models;

namespace OrderManagementSystem.Interfaces
{
    public interface IOrderService
    {
        Task<bool> CreateOrder(OrderCreationDTO orderCreationDTO);
        Task<Order> GetOrder(int id);
        Task<bool> DeleteOrder(int id);
        Task<List<Order>> GetAllOrders();
        Task<decimal> GetAllOrdersAmount(int userId);
    }
}
