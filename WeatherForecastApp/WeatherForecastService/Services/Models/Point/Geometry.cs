using System.Text.Json.Serialization;

public partial class Geometry
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    // [JsonPropertyName("coordinates")]
    // public double[][][] Coordinates { get; set; }
}
