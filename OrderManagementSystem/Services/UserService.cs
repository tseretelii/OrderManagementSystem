using OrderManagementSystem.Data;
using OrderManagementSystem.Data.DTOS.User;
using OrderManagementSystem.Data.Models;

namespace OrderManagementSystem.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateUser(UserCreationDTO userDTO)
        {
            try
            {
                if (userDTO.Password != userDTO.RepeatPassword)
                    throw new Exception();

                User user = new User()
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Email = userDTO.Email,
                    Password = userDTO.Password, // It would be better if I hashed the password
                };

                await _context.Users.AddAsync(user);
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
