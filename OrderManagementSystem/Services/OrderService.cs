using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Data.DTOS.Order;
using OrderManagementSystem.Data.Models;

namespace OrderManagementSystem.Services
{
    public class OrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateOrder(OrderCreationDTO orderDTO)
        {
            try
            {
                var person = _context.Users.FirstOrDefault(u => u.Id == orderDTO.PersonId);

                var products = _context.Products.Where(x => orderDTO.ProductIds.Contains(x.Id)).ToList();

                if (person == null)
                    return false;

                Order order = new Order()
                {
                    Person = person,
                    Products = products
                };

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public async Task<List<Order>> GetAllOrders()
        {
            var orders = new List<Order>();
            try
            {
                orders = await _context.Orders.Include(x => x.Person).Include(x => x.Products).ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                return orders;
            }
        } 
    }
}
