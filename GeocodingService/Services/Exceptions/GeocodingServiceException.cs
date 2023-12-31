namespace GeocodingService.Services;
public class GeocodingServiceException : Exception
{
    public GeocodingServiceException()
    {
    }

    public GeocodingServiceException(string message)
        : base(message)
    {
    }

    public GeocodingServiceException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
