using BasketballInfo.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public interface IUserContract
    {
        
        
        Task<UserDto> RegisterUser(RegisterUserDto userDto);
        Task<UserDto> UserSignUp(UserSignInDto userDto);
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<UserDto> GetUserById(int userId);
    }
}
