using System.Text.Json.Serialization;

namespace GeocodingService.Services.Models;

public partial class GeocodeResponse
{
    [JsonPropertyName("result")]
    public Result? Result { get; set; }
}
