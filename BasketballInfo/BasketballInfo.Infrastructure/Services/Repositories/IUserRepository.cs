using BasketballInfo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Infrastructure.Services.Repositories
{
    public interface IUserRepository
    {
        Task<User> RegisterUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllUsersAsync();
        //Task<User> GetUserByIdAsync(int userId);
        //Task<User> CreateUserAsync(string userName, string email, User user);
        //Task<bool> UserNameAlreadyExists(string username);
        //Task<bool> UserNameforEmailAlreadyExists(string email);
    }
}
