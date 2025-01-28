using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Data.DTOS;
using OrderManagementSystem.Data.DTOS.Order;
using OrderManagementSystem.Data.Models;
using OrderManagementSystem.Interfaces;

namespace OrderManagementSystem.Services
{
    public class OrderService : IOrderService
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
                var person = await _context.Users.FirstOrDefaultAsync(u => u.Id == orderDTO.PersonId);

                var products = await _context.Products.Where(x => orderDTO.ProductIds.Contains(x.Id)).ToListAsync();

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

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteOrder(int id)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

                _context.Orders.Remove(order);
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
        
        public async Task<decimal> GetAllOrdersAmount(int userId) // Sums the prices of the user's purchased products.
        {
            // First Way
            var orders = await _context.Orders
                .Include(o => o.Person)
                .Include(o => o.Products)
                .ToListAsync();

            var userResult = orders.Where(x => x.Person.Id == userId);

            var result = userResult.Select(x => x.Products.Sum(x => x.Price)).ToList()[0];


            // Second Way
            var totalAmount = await
                (from order in _context.Orders
                    where order.Person.Id == userId
                    from product in order.Products
                    select product.Price)
                .SumAsync();

            return totalAmount;
        }

    }
}
