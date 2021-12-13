namespace Youtube2Tonies.WebApi.Clients.Tonies.Models;
public record Chapter
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? File { get; set; }
    public float Seconds { get; set; }
    public bool Transcoding { get; set; }
}