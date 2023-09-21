using FluentValidation;

namespace WeatherForecastService.Validators;
public class ForecastRequestValidator : AbstractValidator<ForecastRequest>
{
    public ForecastRequestValidator()
    {
        RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
    }
}
