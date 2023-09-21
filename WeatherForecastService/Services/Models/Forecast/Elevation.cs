using System.Text.Json.Serialization;

public partial class Elevation
{
    [JsonPropertyName("unitCode")]
    public UnitCode UnitCode { get; set; }

    [JsonPropertyName("value")]
    public double? Value { get; set; }
}
