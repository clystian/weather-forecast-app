using System.Text.Json;

namespace WeatherForecastService.Utils;
public static class JsonExtensions
{
    public static readonly JsonSerializerOptions Settings = new(JsonSerializerDefaults.General)
    {
        Converters =
            {
                UnitCodeConverter.Singleton,
                TemperatureUnitConverter.Singleton,
            },
    };
    public static T? DeserializeObject<T>(this string? json)
    {
        return JsonSerializer.Deserialize<T>(json ?? string.Empty, Settings);
    }

    public static async Task<T?> DeserializeObjectAsync<T>(this Stream stream)
    {
        return await JsonSerializer.DeserializeAsync<T>(stream, Settings);
    }
}
