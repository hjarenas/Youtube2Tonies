using System.Net;
using System.Text.Json;
using Youtube2Tonies.WebApi.Clients.Tonies.Models;

namespace Youtube2Tonies.WebApi.Clients.Tonies;
public class ToniesClient : IToniesClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public ToniesClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
    }
    public async Task<IEnumerable<Household>> HouseholdsGetAsync()
    {
        return await GetAsync<IEnumerable<Household>>("households");
    }

    public async Task<IEnumerable<CreativeTonie>> CreativeToniesGetAsync()
    {
        var households = await HouseholdsGetAsync();
        var creativeTonies = new List<CreativeTonie>();
        foreach (var household in households)
        {
            var creativeToniesForHouseHold = await GetAsync<IEnumerable<CreativeTonie>>($"households/{household.Id}/creativetonies");
            creativeTonies.AddRange(creativeToniesForHouseHold);
        }

        return creativeTonies.DistinctBy(ct => ct.Id);
    }

    private async Task<T> GetAsync<T>(string urlPath)
    {
        var response = await _httpClient.GetAsync(urlPath);
        var content = await response.Content.ReadAsStringAsync();
        if (content == null || !(response.StatusCode == HttpStatusCode.OK))
        {
            throw new ToniesApiException($"The call to the api failed. Status: '{response.StatusCode}'. Body: {content}");
        }

        var result = JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions);
        return result ?? throw new ToniesApiException($"The content could not be deserialized {content}");

    }
}