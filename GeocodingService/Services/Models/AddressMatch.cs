using System.Text.Json.Serialization;

namespace GeocodingService.Services.Models;

public partial class AddressMatch
{
    [JsonPropertyName("tigerLine")]
    public TigerLine? TigerLine { get; set; }

    [JsonPropertyName("coordinates")]
    public Coordinates? Coordinates { get; set; }

    [JsonPropertyName("addressComponents")]
    public AddressComponents? AddressComponents { get; set; }

    [JsonPropertyName("matchedAddress")]
    public string? MatchedAddress { get; set; }
}
