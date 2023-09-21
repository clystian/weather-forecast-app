using System.Text.Json.Serialization;

public partial class WeatherPointResponse
{
    [JsonPropertyName("id")]
    public Uri Id { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("geometry")]
    public Geometry Geometry { get; set; }

    [JsonPropertyName("properties")]
    public PointResponseProperties Properties { get; set; }
}
