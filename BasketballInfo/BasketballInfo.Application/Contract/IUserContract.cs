using BasketballInfo.Application.Dto;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public interface IUserContract
    {
        //Task<IEnumerable<UserDto>> GetAllUsers();
        //Task<UserDto> GetUserByUserId(int userId);
        Task<UserDto> RegisterUser(RegisterUserDto userDto);
    }
}
