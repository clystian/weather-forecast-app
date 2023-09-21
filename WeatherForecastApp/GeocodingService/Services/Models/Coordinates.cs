using System.Text.Json.Serialization;

namespace GeocodingService.Services.Models;

public partial class Coordinates
{
    [JsonPropertyName("x")]
    public double X { get; set; }

    [JsonPropertyName("y")]
    public double Y { get; set; }
}
