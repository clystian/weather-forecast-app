using System.Text.Json.Serialization;

namespace GeocodingService.Services.Models;

public partial class Result
{
    [JsonPropertyName("input")]
    public Input? Input { get; set; }

    [JsonPropertyName("addressMatches")]
    public List<AddressMatch>? AddressMatches { get; set; }
}
