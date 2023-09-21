using System.Text.Json.Serialization;

public partial class Period
{
    [JsonPropertyName("number")]
    public long Number { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("startTime")]
    public DateTimeOffset StartTime { get; set; }

    [JsonPropertyName("endTime")]
    public DateTimeOffset EndTime { get; set; }

    [JsonPropertyName("isDaytime")]
    public bool IsDaytime { get; set; }

    [JsonPropertyName("temperature")]
    public long Temperature { get; set; }

    [JsonPropertyName("temperatureUnit")]
    public TemperatureUnit TemperatureUnit { get; set; }

    [JsonPropertyName("temperatureTrend")]
    public object TemperatureTrend { get; set; }

    [JsonPropertyName("probabilityOfPrecipitation")]
    public Elevation ProbabilityOfPrecipitation { get; set; }

    [JsonPropertyName("dewpoint")]
    public Elevation Dewpoint { get; set; }

    [JsonPropertyName("relativeHumidity")]
    public Elevation RelativeHumidity { get; set; }

    [JsonPropertyName("windSpeed")]
    public string? WindSpeed { get; set; }

    [JsonPropertyName("windDirection")]
    public string? WindDirection { get; set; }

    [JsonPropertyName("icon")]
    public Uri Icon { get; set; }

    [JsonPropertyName("shortForecast")]
    public string? ShortForecast { get; set; }

    [JsonPropertyName("detailedForecast")]
    public string? DetailedForecast { get; set; }
}
