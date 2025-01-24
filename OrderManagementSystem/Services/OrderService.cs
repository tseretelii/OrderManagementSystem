using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Data.DTOS;
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
        //public async Task<List<Order>> GetOrder(OrderGetDTO orderGetDTO) // If user inputs userId - they will get back all orders associated with the user
        //{                                                                // If user inputs OrderId - they will get back a list containing 1 order associated with the given id
        //    if (orderGetDTO.OrderId is null && orderGetDTO.UserId is null)
        //        return default;

        //    if (orderGetDTO.OrderId != null)
        //    {
        //        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == orderGetDTO.UserId);

        //        return await _context.Orders.Include(x => x.Products).Where(x => x.Person == user).ToListAsync();
        //    }
        //    else if (orderGetDTO.UserId != null)
        //    {
        //        return await _context.Orders.Include(x => x.Products).Where(x => x.Person.Id == orderGetDTO.UserId).ToListAsync();
        //    }

        //    return default;
        //}

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
        
        public async Task<List<decimal>> GetAllOrdersAmount(int userId)
        {
            var orders = await _context.Orders
                .Include(o => o.Person)
                .Include(o => o.Products)
                .ToListAsync();

            var result = orders.Select(x => x.Products.Sum(p => p.Price)).ToList();

            return result;
        }
    }
}
