using BasketballInfo.Application.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Services
{
    public interface IJwtService
    {
        string GenerateIdentityToken(UserDto userDto);
    }
}
