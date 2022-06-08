using AutoMapper;
using BasketballInfo.Application.Dto;
using BasketballInfo.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballInfo.Application.Contract
{
    public class UserContract : IUserContract
    {
        private readonly IBasketballInfoRepository _basketballInfoRepository;
        private readonly IMapper _mapper;

        public UserContract(IBasketballInfoRepository basketballInfoRepository, IMapper mapper)
        {
            _basketballInfoRepository = basketballInfoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var userEntities = await _basketballInfoRepository.GetAllUsersAsync();

            return _mapper.Map<IEnumerable<UserDto>>(userEntities);
        }

        public async Task<UserDto> GetUserByUserId(int userId)
        {
            var user = await _basketballInfoRepository.GetUserByUserIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            return (_mapper.Map<UserDto>(user));
        }
    }
}
