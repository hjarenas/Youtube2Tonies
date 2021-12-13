namespace Youtube2Tonies.WebApi.Clients.Tonies;
public interface ITokenProvider
{
    Task<string> GetTokenAsync();
}