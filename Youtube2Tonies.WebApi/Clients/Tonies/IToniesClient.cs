using Youtube2Tonies.WebApi.Clients.Tonies.Models;

namespace Youtube2Tonies.WebApi.Clients.Tonies;
public interface IToniesClient
{
    Task<IEnumerable<Household>> HouseholdsGetAsync();
    Task<IEnumerable<CreativeTonie>> CreativeToniesGetAsync();
}