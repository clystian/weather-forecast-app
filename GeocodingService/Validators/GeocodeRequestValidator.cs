using FluentValidation;

namespace GeocodingService.Validators;
public class GeocodeRequestValidator : AbstractValidator<GeocodeRequest>
{
    public GeocodeRequestValidator()
    {
        RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
    }
}
