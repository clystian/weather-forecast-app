namespace WeatherForecastService.Utils;
public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage> GetAsync(this HttpClient client, string requestUri, Dictionary<string, string> parameters)
    {
        var query = await new FormUrlEncodedContent(parameters).ReadAsStringAsync();
        return await client.GetAsync($"{requestUri}?{query}");
    }
}
