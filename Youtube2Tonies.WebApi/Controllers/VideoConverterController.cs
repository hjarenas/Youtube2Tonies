using Microsoft.AspNetCore.Mvc;
using Youtube2Tonies.WebApi.Services;

namespace Youtube2Tonies.WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class VideoConverterController : Controller
{
    private readonly IVideoConverter _videoConverter;

    public VideoConverterController(IVideoConverter videoConverter)
    {
        _videoConverter = videoConverter;
    }
    [HttpGet()]
    public IActionResult ConvertVideo([FromQuery] Uri videoUri)
    {
        var audioFile = _videoConverter.ConvertVideo(videoUri);
        if(audioFile is null || audioFile.Content is null || audioFile.ContentType is null)
        {
            return Problem("There was an error converting the file");
        }
        return File(audioFile.Content, audioFile.ContentType, audioFile.Name);
    }
}