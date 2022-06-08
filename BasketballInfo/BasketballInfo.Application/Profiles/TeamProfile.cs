using AutoMapper;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;

namespace BasketballInfo.Application.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDto>();
            CreateMap<Team, TeamWithPlayersDto>();
            CreateMap<Team, TeamWithCoachesDto>();
            CreateMap<Team, TeamWithCoachAndPlayerDto>();
        }
    }
}
