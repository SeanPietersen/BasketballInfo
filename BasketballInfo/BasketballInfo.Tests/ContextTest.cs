using AutoMapper;
using BasketballInfo.Application.Profiles;

namespace BasketballInfo.Tests
{
    public class ContextTest
    {
        public static IMapper _mapper;

        public ContextTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new TeamProfile());
                    mc.AddProfile(new PlayerProfile());
                    mc.AddProfile(new CoachProfile());
                    mc.AddProfile(new UserProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
    }
}
