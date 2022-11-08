using Tweetbook.Services;

namespace Tweetbook.Installers;

public class DbInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    { 
        services.AddSingleton<IPostService, PostService>();
    }
}