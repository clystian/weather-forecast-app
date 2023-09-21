using System.Text.Json.Serialization;

public partial class PointResponseProperties
{
    [JsonPropertyName("@id")]
    public Uri Id { get; set; }

    [JsonPropertyName("@type")]
    public string? Type { get; set; }

    [JsonPropertyName("cwa")]
    public string? Cwa { get; set; }

    [JsonPropertyName("forecastOffice")]
    public Uri ForecastOffice { get; set; }

    [JsonPropertyName("gridId")]
    public string? GridId { get; set; }

    [JsonPropertyName("gridX")]
    public long GridX { get; set; }

    [JsonPropertyName("gridY")]
    public long GridY { get; set; }

    [JsonPropertyName("forecast")]
    public Uri Forecast { get; set; }

    [JsonPropertyName("forecastHourly")]
    public Uri ForecastHourly { get; set; }

    [JsonPropertyName("forecastGridData")]
    public Uri ForecastGridData { get; set; }

    [JsonPropertyName("observationStations")]
    public Uri ObservationStations { get; set; }

    [JsonPropertyName("relativeLocation")]
    public RelativeLocation RelativeLocation { get; set; }

    [JsonPropertyName("forecastZone")]
    public Uri ForecastZone { get; set; }

    [JsonPropertyName("county")]
    public Uri County { get; set; }

    [JsonPropertyName("fireWeatherZone")]
    public Uri FireWeatherZone { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }

    [JsonPropertyName("radarStation")]
    public string? RadarStation { get; set; }
}
