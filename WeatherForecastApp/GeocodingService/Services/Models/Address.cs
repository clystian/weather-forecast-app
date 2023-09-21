using System.Text.Json.Serialization;

namespace GeocodingService.Services.Models;

public partial class Address
{
    [JsonPropertyName("address")]
    public string? AddressAddress { get; set; }
}
