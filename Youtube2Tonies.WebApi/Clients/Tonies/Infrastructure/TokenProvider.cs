using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace Youtube2Tonies.WebApi.Clients.Tonies;
public class TokenProvider : ITokenProvider
{
    private readonly HttpClient _httpClient;
    private readonly PasswordTokenRequest _passwordTokenOptions;
    private readonly SemaphoreSlim _semaphoreSlim;
    private string _accessToken = string.Empty;
    private DateTime _expirationTime = DateTime.Now;

    public TokenProvider(HttpClient httpClient, IOptions<PasswordTokenRequest> passwordTokenOptions)
    {
        _httpClient = httpClient;
        _passwordTokenOptions = passwordTokenOptions.Value;
        _semaphoreSlim = new SemaphoreSlim(1, 1);
    }
    public async Task<string> GetTokenAsync()
    {
        await _semaphoreSlim.WaitAsync();
        try
        {
            if (_expirationTime < DateTime.Now.AddSeconds(30))
            {
                var passwordToken = await _httpClient.RequestPasswordTokenAsync(_passwordTokenOptions);
                _accessToken = passwordToken.AccessToken;
                _expirationTime = DateTime.Now.AddSeconds(passwordToken.ExpiresIn);
            }
        }
        finally
        {
            _semaphoreSlim.Release();
        }
        return _accessToken;
    }
}