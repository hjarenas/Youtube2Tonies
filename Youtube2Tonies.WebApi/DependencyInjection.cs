using IdentityModel.Client;
using VideoLibrary;
using Youtube2Tonies.WebApi.Clients.Tonies;
using Youtube2Tonies.WebApi.Services;

namespace Youtube2Tonies.WebApi;

public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PasswordTokenRequest>(configuration.GetSection("ToniesAuth"));
        services.AddSingleton<ITokenProvider, TokenProvider>();
        services.AddTransient<ToniesOAuthHandler>();
        services.AddHttpClient<IToniesClient, ToniesClient>(nameof(ToniesClient), (client) =>
            {
                client.BaseAddress = new Uri("https://api.tonie.cloud/v2/");
            })
            .AddHttpMessageHandler<ToniesOAuthHandler>();
        services.AddScoped<YouTube>((serv) => YouTube.Default);
        services.AddScoped<IVideoConverter, VideoConverter>();
    }
}