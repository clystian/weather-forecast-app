namespace WeatherForecastService.Models.Dto;
 public class ForecastResponse
    {
        public List<DayForecast> DayForecasts { get; set; }
    }

    public class DayForecast
    {
        public DateTimeOffset Date { get; set; }
        public long Temperature { get; set; }
        public string? TemperatureUnit { get; set; }
        public string? ShortForecast { get; set; }
        public Uri? Icon { get; set; }
    }