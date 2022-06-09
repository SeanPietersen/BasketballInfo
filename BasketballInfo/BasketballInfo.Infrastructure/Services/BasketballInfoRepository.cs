using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketballInfo.Infrastructure.Services
{
    public class BasketballInfoRepository
    {
        private readonly BasketballInfoContext _context;

        public BasketballInfoRepository(BasketballInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        
    }
}
