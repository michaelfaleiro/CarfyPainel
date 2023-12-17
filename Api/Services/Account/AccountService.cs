using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Account
{
    public class AccountService(DbApiContext context) : IAccountService
    {
        private readonly DbApiContext _context = context;

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.AsNoTracking().Include(x => x.Roles).FirstOrDefaultAsync(x => x.Email == email);

            return user;
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<User> Login(User user)
        {
            throw new NotImplementedException();
        }

        public Task Logout()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}