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
            CreateMap<CoachForCreationDto, Coach>();
            CreateMap<CoachForUpdateDto, Coach>();
            CreateMap<Coach, CoachForUpdateDto>();
        }
    }
}
