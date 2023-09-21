using System.Text.Json.Serialization;

public partial class Bearing
{
    [JsonPropertyName("unitCode")]
    public string? UnitCode { get; set; }

    [JsonPropertyName("value")]
    public double Value { get; set; }
}