namespace Youtube2Tonies.WebApi.Clients.Tonies;
[System.Serializable]
public class ToniesApiException : System.Exception
{
    public ToniesApiException() { }
    public ToniesApiException(string message) : base(message) { }
    public ToniesApiException(string message, System.Exception inner) : base(message, inner) { }
    protected ToniesApiException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}