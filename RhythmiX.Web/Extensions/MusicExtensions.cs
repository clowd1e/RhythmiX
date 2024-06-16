using RhythmiX.Storage;
using RhythmiX.Storage.Repository;
using RhythmiX.Web.Services.UserService;

namespace RhythmiX.Web.Extensions
{
    public static class MusicExtensions
    {
        public static IServiceCollection AddMusicServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMusicRepository, MusicRepository>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddDbContext<MusicDbContext, MusicDbContext>();

            serviceCollection.AddSingleton<IUserService, UserService>();

            return serviceCollection;
        }
    }
}
