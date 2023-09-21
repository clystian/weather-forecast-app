using GeocodingService.Services;
using GeocodingService.Services.Models;
using GeocodingService.Validators;
using Microsoft.AspNetCore.Mvc;

namespace GeocodingService.Controllers;

[ApiController]
[Route("[controller]")]
public class GeocodingController : ControllerBase
{
    private readonly IGeocodingService _geocodingService;
    private readonly GeocodeRequestValidator _singleValidator;
    private readonly BulkGeocodeRequestValidator _bulkValidator;

    public GeocodingController(IGeocodingService geocodingService, GeocodeRequestValidator singleValidator, BulkGeocodeRequestValidator bulkValidator)
    {
        _geocodingService = geocodingService;
        _singleValidator = singleValidator;
        _bulkValidator = bulkValidator;
    }

    [HttpGet("single")]
    public async Task<IActionResult> GetSingle([FromQuery] GeocodeRequest request)
    {
        var validationResult = _singleValidator.Validate(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var response = await _geocodingService.GetCoordinates(request.Address);

        var geoResponse = TransformToGeoResponse(response?.Result);

        if (geoResponse == null)
        {
            return NotFound("No address matches found.");
        }

        return Ok(geoResponse);
    }

    [HttpPost("bulk")]
    public async Task<IActionResult> GetBulkAsync([FromBody] BulkGeocodeRequest request)
    {
        var validationResult = _bulkValidator.Validate(request);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var responses = await _geocodingService.GetBulkCoordinates(request.Addresses);

        var geoBulkResponse = new GeoBulkResponse
        {
            Results = responses.Select(r => TransformToGeoResponse(r?.Result)).Where(gr => gr != null).OfType<GeoResponse>().ToList()
        };

        return Ok(geoBulkResponse);
    }

    internal static GeoResponse? TransformToGeoResponse(Result? result)
    {
        var firstMatch = result?.AddressMatches?.FirstOrDefault();

        if (firstMatch == null) return null;

        return new GeoResponse
        {
            Address = firstMatch.MatchedAddress,
            Latitude = firstMatch.Coordinates?.Y ?? 0.0,
            Longitude = firstMatch.Coordinates?.X ?? 0.0,
            Zip = firstMatch.AddressComponents?.Zip,
            StreetName = firstMatch.AddressComponents?.StreetName,
            City = firstMatch.AddressComponents?.City,
            State = firstMatch.AddressComponents?.State
        };
    }
}

