using WeatherForecastService.Utils;

namespace WeatherForecastService.Services;
public class WeatherGovService : IWeatherGovService
{
    private readonly HttpClient _httpClient;

    public WeatherGovService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "NombreDeTuAplicacion");
    }

    public async Task<WeatherPointResponse?> GetPoint(double latitude, double longitude)
    {
        var response = await _httpClient.GetAsync($"/points/{latitude:F4},{longitude:F4}" );
        var str1 = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            var str2 = await response.Content.ReadAsStringAsync();
            var stream = await response.Content.ReadAsStreamAsync();
            return await stream.DeserializeObjectAsync<WeatherPointResponse>();
        }

        return null;
    }

    public async Task<WeatherForecastResponse?> GetForecast(string gridId, long x, long y)
    {
        var response = await _httpClient.GetAsync($"/gridpoints/{gridId}/{x},{y}/forecast");

        if (response.IsSuccessStatusCode)
        {
            var str2 = await response.Content.ReadAsStringAsync();
            var stream = await response.Content.ReadAsStreamAsync();
            return await stream.DeserializeObjectAsync<WeatherForecastResponse>();
        }

        return null;
    }
}