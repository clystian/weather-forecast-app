using WeatherForecastService.Models.Dto;

namespace WeatherForecastService.Services;

public interface IForecastService
{
    Task<ForecastResponse> GetWeatherForecasts(string address);

}
