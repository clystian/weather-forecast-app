using System.Text.Json.Serialization;

namespace WeatherForecastService.Services.Models.Geo;

public class GeoResponse
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
    [JsonPropertyName("zip")]
    public string? Zip { get; set; }

    [JsonPropertyName("streetName")]
    public string? StreetName { get; set; }
    [JsonPropertyName("city")]
    public string? City { get; set; }
    [JsonPropertyName("state")]
    public string? State { get; set; }
}
