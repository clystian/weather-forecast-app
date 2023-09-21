using System.Text.Json.Serialization;

namespace GeocodingService.Services.Models;

public partial class Input
{
    [JsonPropertyName("address")]
    public Address? Address { get; set; }

    [JsonPropertyName("benchmark")]
    public Benchmark? Benchmark { get; set; }
}
