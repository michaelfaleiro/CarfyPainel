using Api.Data;
using Api.Models;

namespace Api.Services.Account
{
    public interface IAccountService
    {
        Task<User> CreateUserAsync(User user);

        Task<User?> GetUserByIdAsync(Guid id);

        Task<User?> GetUserByEmailAsync(string email);

        Task<User> UpdateUserAsync(User user);

        Task<User> DeleteUserAsync(User user);

        Task<User> Login(User user);

        Task Logout();
    }
}