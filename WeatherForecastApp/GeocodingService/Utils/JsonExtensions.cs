using System.Text.Json;

namespace GeocodingService.Utils;
public static class JsonExtensions
{
    public static T? DeserializeObject<T>(this string? json)
    {
        return JsonSerializer.Deserialize<T>(json ?? string.Empty);
    }

    public static async Task<T?> DeserializeObjectAsync<T>(this Stream stream)
    {
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }
}
