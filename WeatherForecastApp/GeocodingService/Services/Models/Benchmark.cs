using System.Text.Json.Serialization;

namespace GeocodingService.Services.Models;

public partial class Benchmark
{
    [JsonPropertyName("isDefault")]
    public bool IsDefault { get; set; }

    [JsonPropertyName("benchmarkDescription")]
    public string? BenchmarkDescription { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("benchmarkName")]
    public string? BenchmarkName { get; set; }
}