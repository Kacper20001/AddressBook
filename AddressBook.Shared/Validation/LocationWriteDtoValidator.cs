using AddressBook.Shared.DTOs.Location;
using FluentValidation;

namespace AddressBook.Shared.Validation
{
    /// <summary>
    /// Validator for the LocationWriteDto using FluentValidation.
    /// </summary>
    public class LocationWriteDtoValidator : AbstractValidator<LocationWriteDto>
    {
        /// <summary>
        /// Initializes validation rules for LocationWriteDto.
        /// </summary>
        public LocationWriteDtoValidator()
        {
            RuleFor(x => x.CityName)
                .NotEmpty().WithMessage("City name is required.")
                .Length(2, 100).WithMessage("City name must be between 2 and 100 characters.");

            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("Postal code is required.")
                // Regex: Format XX-XXX
                .Matches(@"^\d{2}-\d{3}$").WithMessage("Postal code must be in format 00-000.");
        }
    }
}
