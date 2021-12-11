using VideoLibrary;
using Youtube2Tonies.WebApi.Services;

namespace Youtube2Tonies.WebApi;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<YouTube>((serv) => YouTube.Default);
        services.AddScoped<IVideoConverter, VideoConverter>();
    }
}