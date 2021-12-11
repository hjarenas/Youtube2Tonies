namespace Youtube2Tonies.WebApi.Models;
public record AudioFile
{
    public byte[]? Content { get; set; }
    public string? Name { get; set; }
    public string? ContentType { get; set; }
}