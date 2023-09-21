using FluentValidation;

namespace GeocodingService.Validators;
public class BulkGeocodeRequestValidator : AbstractValidator<BulkGeocodeRequest>
{
    public BulkGeocodeRequestValidator()
    {
        RuleFor(x => x.Addresses).NotEmpty().WithMessage("Addresses are required.");
    }
}
