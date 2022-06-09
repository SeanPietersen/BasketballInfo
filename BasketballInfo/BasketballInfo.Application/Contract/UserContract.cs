using AutoMapper;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;
using BasketballInfo.Infrastructure.Services;
using BasketballInfo.Infrastructure.Services.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public class UserContract : IUserContract
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserContract(IUserRepository userRepsitory, IMapper mapper)
        {
            _userRepository = userRepsitory;
            _mapper = mapper;
        }

        public UserDto RegisterUser(RegisterUserDto userDto)
        {
            //check if email exists
            var userEmailCheck = _userRepository.GetUserByEmailAsync(userDto.Email);

            if (userEmailCheck != null)
            {
                // email exists
                return null;
            }

            //creating a user
            var createdUser = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password
            };

            var user = _userRepository.RegisterUser(createdUser);

            return _mapper.Map<UserDto>(user);
        }

        //public Task<UserDto> RegisterUser(string userName, string email, RegisterUserDto userDto)
        //{
        //    throw new System.NotImplementedException();
        //}

        //public async Task<IEnumerable<UserDto>> GetAllUsers()
        //{
        //    var userEntities = await _basketballInfoRepository.GetAllUsersAsync();

        //    return _mapper.Map<IEnumerable<UserDto>>(userEntities);
        //}

        //public async Task<UserDto> GetUserByUserId(int userId)
        //{
        //    var user = await _basketballInfoRepository.GetUserByUserIdAsync(userId);

        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    return (_mapper.Map<UserDto>(user));
        //}
    }
}
