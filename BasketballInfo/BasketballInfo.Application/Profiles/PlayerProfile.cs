using AutoMapper;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;

namespace BasketballInfo.Application.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<CreatePlayerDto, Player>();
            CreateMap<UpdatePlayerDto, Player>();
            CreateMap<Player, UpdatePlayerDto>();
        }
    }
}
