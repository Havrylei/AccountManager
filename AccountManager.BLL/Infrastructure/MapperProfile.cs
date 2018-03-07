using AutoMapper;
using AccountManager.BLL.Infrastructure.Profiles;

namespace AccountManager.BLL.Infrastructure
{
    public static class MapperProfile
    {
        public static IMapper Instance;

        static MapperProfile()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<UserProfile>();
                config.AddProfile<UserRatingProfile>();
                config.AddProfile<RegistrateUserProfile>();
                config.AddProfile<EditUserProfile>();
            });

            Instance = mapperConfiguration.CreateMapper();
        }
    }
}
