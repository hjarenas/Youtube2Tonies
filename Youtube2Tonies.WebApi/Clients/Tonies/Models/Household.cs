namespace Youtube2Tonies.WebApi.Clients.Tonies.Models;
public record Household
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public string? OwnerName { get; set; }
}