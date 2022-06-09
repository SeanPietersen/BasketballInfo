using BasketballInfo.Application.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public interface IUserContract
    {
        
        //Task<UserDto> GetUserByUserId(int userId);
        Task<UserDto> RegisterUser(RegisterUserDto userDto);
        Task<UserDto> UserSignUp(UserSignUpDto userDto);
        Task<IEnumerable<UserDto>> GetAllUsers();
    }
}
