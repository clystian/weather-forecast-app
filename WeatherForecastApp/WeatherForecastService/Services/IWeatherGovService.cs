namespace WeatherForecastService.Services;

public interface IWeatherGovService
{
    Task<WeatherPointResponse?> GetPoint(double latitude, double longitude);
    Task<WeatherForecastResponse?> GetForecast(string gridId, long x, long y);
}
