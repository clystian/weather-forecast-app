using GeocodingService.Services.Models;
using GeocodingService.Utils;

namespace GeocodingService.Services;
public class GeocodingService : IGeocodingService
{
    private readonly HttpClient _httpClient;

    public GeocodingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GeocodeResponse> GetCoordinates(string postalAddress)
    {
        var parameters = new Dictionary<string, string>
        {
            ["address"] = postalAddress,
            ["benchmark"] = "Public_AR_Census2020",
            ["format"] = "json"
        };
        var response = await _httpClient.GetAsync("locations/onelineaddress", parameters);

        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            return await stream.DeserializeObjectAsync<GeocodeResponse>();
        }
        else
        {
            var stream = await response.Content.ReadAsStreamAsync();
            var errorResponse = await stream.DeserializeObjectAsync<GeocodingErrorResponse>() ?? new GeocodingErrorResponse { Errors = new List<string>() };
            throw new GeocodingServiceException(string.Join(", ", errorResponse.Errors));
        }
    }

    public async Task<List<GeocodeResponse>> GetBulkCoordinates(List<string> postalAddresses)
    {
        var tasks = postalAddresses.Select(GetCoordinates);
        var responses = await Task.WhenAll(tasks);
        return responses.ToList();
    }

    public async Task<GeocodeResponse> GetAddress(Coordinates coordinate)
    {
        var parameters = new Dictionary<string, string>
        {
            ["x"] = coordinate.X.ToString(),
            ["y"] = coordinate.Y.ToString(),
            ["benchmark"] = "Public_AR_Census2020",
            ["vintage"] = "Census2020_Current",
            ["layers"] = "14",
            ["format"] = "json"
        };
        var response = await _httpClient.GetAsync("geographies/coordinates", parameters);
        var stream = await response.Content.ReadAsStreamAsync();

        if (response.IsSuccessStatusCode)
        {

            return await stream.DeserializeObjectAsync<GeocodeResponse>();
        }
        else
        {
            var errorResponse = await stream.DeserializeObjectAsync<GeocodingErrorResponse>();
            throw new GeocodingServiceException(string.Join(", ", errorResponse?.Errors));
        }
    }

    public async Task<List<GeocodeResponse>> GetBulkAddresses(List<Coordinates> coordinates)
    {
        var tasks = coordinates.Select(GetAddress);
        var responses = await Task.WhenAll(tasks);
        return responses.ToList();
    }
}
