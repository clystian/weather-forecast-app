using Microsoft.AspNetCore.Mvc;
using WeatherForecastService.Services;
using WeatherForecastService.Validators;

namespace WeatherForecastService.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IForecastService _forecastService;
        private readonly ForecastRequestValidator _forecastValidator;

        public WeatherForecastController(IForecastService forecastService, ForecastRequestValidator forecastValidator)
        {
            _forecastService = forecastService;
            _forecastValidator = forecastValidator;
        }

        [HttpGet("lastdays")]
        public async Task<IActionResult> GetForecast([FromQuery] ForecastRequest request)
        {
            var validationResult = _forecastValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var forecastResponse = await _forecastService.GetWeatherForecasts(request.Address);
                return Ok(forecastResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
