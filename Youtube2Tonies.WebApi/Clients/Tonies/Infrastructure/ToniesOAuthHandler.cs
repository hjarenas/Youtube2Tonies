using System.Net.Http.Headers;

namespace Youtube2Tonies.WebApi.Clients.Tonies;
public class ToniesOAuthHandler : DelegatingHandler
{
    private readonly ITokenProvider _tokenProvider;

    public ToniesOAuthHandler(ITokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _tokenProvider.GetTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return await base.SendAsync(request, cancellationToken);
    }
}