using BasketballInfo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Infrastructure.Services
{
    public interface IBasketballInfoRepository
    {
        
       
        Task<bool> SaveChangesAsync();
        
    }
}
