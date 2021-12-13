using Microsoft.AspNetCore.Mvc;
using Youtube2Tonies.WebApi.Clients.Tonies;
using Youtube2Tonies.WebApi.Clients.Tonies.Models;

namespace Youtube2Tonies.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToniesController : ControllerBase
{
    private readonly IToniesClient _toniesClient;

    public ToniesController(IToniesClient toniesClient)
    {
        _toniesClient = toniesClient;
    }

    [HttpGet]
    public async Task<IEnumerable<Household>> GetHouseHoldsAsync()
    {
        return await _toniesClient.HouseholdsGetAsync();
    }

    [Route("creativeTonies")]
    [HttpGet]
    public async Task<IEnumerable<CreativeTonie>> GetCreativeToniesAsync()
    {
        return await _toniesClient.CreativeToniesGetAsync();
    }
}
