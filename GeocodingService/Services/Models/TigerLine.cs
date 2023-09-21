using System.Text.Json.Serialization;

namespace GeocodingService.Services.Models;

public partial class TigerLine
{
    [JsonPropertyName("side")]
    public string? Side { get; set; }

    [JsonPropertyName("tigerLineId")]
    public string? TigerLineId { get; set; }
}
