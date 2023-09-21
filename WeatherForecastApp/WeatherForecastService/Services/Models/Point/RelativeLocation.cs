using System.Text.Json.Serialization;

public partial class RelativeLocation
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("geometry")]
    public Geometry Geometry { get; set; }

    [JsonPropertyName("properties")]
    public RelativeLocationProperties Properties { get; set; }
}
