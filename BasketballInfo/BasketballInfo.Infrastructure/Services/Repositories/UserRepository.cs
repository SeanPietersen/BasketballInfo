using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballInfo.Infrastructure.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BasketballInfoContext _context;

        public UserRepository(BasketballInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                return await _context.Users.Where(s => s.Email == email).FirstOrDefaultAsync<User>();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<User> RegisterUserAsync(User user)
        {
            var entity = await _context.Users.AddAsync(user);

            if (entity.State == EntityState.Added)
            {
                _context.SaveChanges();
            }

            return entity.Entity;
        }

        //public async Task RegisterUserAsync(User user)
        //{
        //    var entity = _context.Users.Add(user).;
        //    return _context.Users.Add(user);
        //}
        //public async Task<IEnumerable<User>> GetAllUsersAsync()
        //{
        //    return await _context.Users.OrderBy(c => c.FirstName).ToListAsync();
        //}

        //public async Task<bool> UserForUserIdExists(int userId)
        //{
        //    return await _context.Users.AnyAsync(c => c.UserId == userId);
        //}

        //public async Task<User> GetUserByIdAsync(int userId)
        //{
        //    return await _context.Users.Where(c => c.UserId == userId).FirstOrDefaultAsync();
        //}

        //public async Task CreateUserByUserNameAsync(string userName, string email, User user)
        //{
        //    var userToCreateUserName = await UserNameAlreadyExists(userName);
        //    var userToCreateEmail = await UserNameforEmailAlreadyExists(email);

        //    if (!userToCreateUserName)
        //    {
        //        if (!userToCreateEmail)
        //        {
        //            User.Add(user);
        //        }

        //    }
        //}

        //public async Task<bool> UserNameAlreadyExists(string userName)
        //{
        //    return await _context.Users.AnyAsync(c => c.UserName == userName);
        //}

        //public async Task<bool> UserNameforEmailAlreadyExists(string email)
        //{
        //    return await _context.Users.AnyAsync(c => c.Email == email);
        //}
    }
}
