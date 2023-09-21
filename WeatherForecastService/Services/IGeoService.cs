using WeatherForecastService.Services.Models.Geo;

namespace WeatherForecastService.Services;

public interface IGeoService
{
    Task<GeoResponse> GetCoordinatesAsync(string address);
    Task<GeoBulkResponse> GetBulkCoordinatesAsync(List<string> addresess);
}
