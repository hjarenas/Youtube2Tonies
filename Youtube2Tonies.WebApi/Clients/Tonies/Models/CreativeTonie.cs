namespace Youtube2Tonies.WebApi.Clients.Tonies.Models;

public record CreativeTonie
{
    public string? Id { get; set; }
    public Guid HouseholdId { get; set; }
    public string? Name { get; set; }
    public bool Live { get; set; }
    public bool Private { get; set; }
    public string? ImageUrl { get; set; }
    public IEnumerable<Chapter>? MyProperty { get; set; }
}
