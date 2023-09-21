using System.Text.Json.Serialization;

public partial class WeatherForecastResponse
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    //[JsonPropertyName("geometry")]
    //public Geometry Geometry { get; set; }

    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }
}
