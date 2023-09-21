using GeocodingService.Services.Models;

namespace GeocodingService.Services;

public interface IGeocodingService
{
    Task<GeocodeResponse> GetCoordinates(string postalAddress);
    Task<List<GeocodeResponse>> GetBulkCoordinates(List<string> postalAddresses);
    Task<GeocodeResponse> GetAddress(Coordinates coordinate);
    Task<List<GeocodeResponse>> GetBulkAddresses(List<Coordinates> coordinates);
}
