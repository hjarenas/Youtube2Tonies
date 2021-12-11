using Youtube2Tonies.WebApi.Models;

namespace Youtube2Tonies.WebApi.Services;
public interface IVideoConverter
{
    AudioFile ConvertVideo(Uri uri);
}