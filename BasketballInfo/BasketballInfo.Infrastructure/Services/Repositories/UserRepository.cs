﻿using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.OrderBy(c => c.FirstName).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _context.Users.Where(c => c.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
