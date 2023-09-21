using System.Text;
using System.Text.Json;
using WeatherForecastService.Services.Models.Geo;
using WeatherForecastService.Utils;

namespace WeatherForecastService.Services;

public class GeoService : IGeoService
{
    private readonly HttpClient _httpClient;

    public GeoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GeoResponse> GetCoordinatesAsync(string address)
    {
        var parameters = new Dictionary<string, string>
            {
                { "Address", address }
            };

        HttpResponseMessage response = await _httpClient.GetAsync("Geocoding/single", parameters);

        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            var geoResponse = await stream.DeserializeObjectAsync<GeoResponse>();
            if (geoResponse != null)
            {
                return geoResponse;
            }
        }

        throw new Exception("Failed to get coordinates.");
    }

    public async Task<GeoBulkResponse> GetBulkCoordinatesAsync(List<string> addresses)
    {
        var requestBody = new { Addresses = addresses };
        var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync("Geocoding/bulk", content);

        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            var geoBulkResponse = await stream.DeserializeObjectAsync<GeoBulkResponse>();
            if (geoBulkResponse != null)
            {
                return geoBulkResponse;
            }
        }

        throw new Exception("Failed to get bulk coordinates.");
    }
}
