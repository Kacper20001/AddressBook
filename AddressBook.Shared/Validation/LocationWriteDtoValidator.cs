using AddressBook.Shared.DTOs.Location;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.Validation
{
    public class LocationWriteDtoValidator : AbstractValidator<LocationWriteDto>
    {
        public LocationWriteDtoValidator()
        {
            RuleFor(x => x.CityName)
                .NotEmpty().WithMessage("City name is required.")
                .Length(2, 100).WithMessage("City name must be between 2 and 100 characters.");

            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("Postal code is required.")
                .Matches(@"^\d{2}-\d{3}$").WithMessage("Postal code must be in format 00-000.");
        }
    }
}
