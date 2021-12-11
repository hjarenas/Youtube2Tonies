using NAudio.Wave;
using VideoLibrary;
using Youtube2Tonies.WebApi.Models;

namespace Youtube2Tonies.WebApi.Services;
public class VideoConverter : IVideoConverter
{
    private const string WavExtension = ".wav";
    private readonly YouTube _youtube;

    public VideoConverter(YouTube youtubeRef)
    {
        _youtube = youtubeRef;
    }

    public AudioFile ConvertVideo(Uri uri)
    {
        var video = _youtube.GetVideo(uri.ToString());
        File.WriteAllBytes(video.FullName, video.GetBytes());
        var wavName = video.Title + WavExtension;
        using var reader = new MediaFoundationReader(video.FullName);
        WaveFileWriter.CreateWaveFile(wavName, reader);
        var audioBytes = File.ReadAllBytes(wavName);

        File.Delete(video.FullName);
        File.Delete(wavName);
        return new AudioFile { Content = audioBytes, Name = wavName, ContentType = "audio/wav" };
    }
}