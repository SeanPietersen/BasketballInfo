using AutoMapper;
using BasketballInfo.Application.Dto;
using BasketballInfo.Domain;

namespace BasketballInfo.Application.Profiles
{
    public class CoachProfile : Profile
    {
        public CoachProfile()
        {
            CreateMap<Coach, CoachDto>();
            CreateMap<CreateCoachDto, Coach>();
            CreateMap<UpdateCoachDto, Coach>();
            CreateMap<Coach, UpdateCoachDto>();
        }
    }
}
