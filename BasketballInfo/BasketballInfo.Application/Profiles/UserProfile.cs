using AutoMapper;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;

namespace BasketballInfo.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
