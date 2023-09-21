namespace GeocodingService.Validators;

public class GeoResponse
{
    public string? Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Zip { get; set; }
    public string? StreetName { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
}
