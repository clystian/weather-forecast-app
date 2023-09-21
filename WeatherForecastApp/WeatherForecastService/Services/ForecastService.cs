using WeatherForecastService.Models.Dto;
using WeatherForecastService.Utils;
using System;
using System.Threading.Tasks;
using WeatherForecastService.Services.Models;
using WeatherForecastService.Services.Models.Geo;

namespace WeatherForecastService.Services;
public class ForecastService : IForecastService
{
    private readonly IGeoService _geoService;
    private readonly IWeatherGovService _weatherGovService;

    public ForecastService(IGeoService geoService, IWeatherGovService weatherGovService)
    {
        _geoService = geoService;
        _weatherGovService = weatherGovService;
    }

    public async Task<ForecastResponse> GetWeatherForecasts(string address)
    {
        //  Get Geo Coordinates
        GeoResponse geoResponse = await _geoService.GetCoordinatesAsync(address);
        if (geoResponse == null)
        {
            throw new Exception("Could not get Geo Coordinates.");
        }

        //  Get Weather Point
        WeatherPointResponse? pointResponse = await _weatherGovService.GetPoint(geoResponse.Latitude, geoResponse.Longitude);
        if (pointResponse?.Properties == null)
        {
            throw new Exception("Could not get Weather Point.");
        }

        // Get Weather Forecast
        var gridId = pointResponse.Properties.GridId ?? string.Empty;
        var gridX = pointResponse.Properties.GridX;
        var gridY = pointResponse.Properties.GridY;

        WeatherForecastResponse? forecastResponse = await _weatherGovService.GetForecast(gridId, gridX, gridY);
        if (forecastResponse == null)
        {
            throw new Exception("Could not get Weather Forecast.");
        }

        // Transform to ForecastResponse
        ForecastResponse finalResponse = TransformToForecastResponse(forecastResponse);

        return finalResponse;
    }

    private ForecastResponse TransformToForecastResponse(WeatherForecastResponse forecast)
    {
        var lastDaysForecast = new ForecastResponse
        {
            DayForecasts = forecast.Properties.Periods.Select(p => new DayForecast
            {
                Date = p.StartTime,
                Temperature = p.Temperature,
                TemperatureUnit = p.TemperatureUnit.ToString(),
                ShortForecast = p.ShortForecast,
                Icon = p.Icon
            }).ToList()
        };

        return lastDaysForecast;
    }
}

