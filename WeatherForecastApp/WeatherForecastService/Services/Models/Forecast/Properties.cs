using System.Text.Json.Serialization;

public partial class Properties
{
    [JsonPropertyName("updated")]
    public DateTimeOffset Updated { get; set; }

    [JsonPropertyName("units")]
    public string? Units { get; set; }

    [JsonPropertyName("forecastGenerator")]
    public string? ForecastGenerator { get; set; }

    [JsonPropertyName("generatedAt")]
    public DateTimeOffset GeneratedAt { get; set; }

    [JsonPropertyName("updateTime")]
    public DateTimeOffset UpdateTime { get; set; }

    [JsonPropertyName("validTimes")]
    public string? ValidTimes { get; set; }

    [JsonPropertyName("elevation")]
    public Elevation Elevation { get; set; }

    [JsonPropertyName("periods")]
    public List<Period> Periods { get; set; }
}
