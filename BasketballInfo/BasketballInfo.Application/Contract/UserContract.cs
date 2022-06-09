using AutoMapper;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;
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

        public async Task<UserDto> RegisterUser(RegisterUserDto userDto)
        {
            //check if email exists
            var userEmailCheck = await _userRepository.GetUserByEmailAsync(userDto.Email);

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

            await _userRepository.RegisterUserAsync(createdUser);

            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task<UserDto> UserSignUp(UserSignUpDto userDto)
        {
            //check if email exists
            var userEmailCheck = await _userRepository.GetUserByEmailAsync(userDto.Email);

            if (userEmailCheck == null)
            {
                // email/username doesnt exists
                return null;
            }

            //check if password matches email
            if(userEmailCheck.Password != userDto.Password)
            {
                return null;
            }

            var user = new User()
            {
                FirstName = userEmailCheck.FirstName,
                LastName = userEmailCheck.LastName,
            };
            //successful signup returns user
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var userEntities = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(userEntities);
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            return (_mapper.Map<UserDto>(user));
        }
    }
}
