using System.Text.Json.Serialization;

public partial class RelativeLocationProperties
{
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("distance")]
    public Bearing Distance { get; set; }

    [JsonPropertyName("bearing")]
    public Bearing Bearing { get; set; }
}
