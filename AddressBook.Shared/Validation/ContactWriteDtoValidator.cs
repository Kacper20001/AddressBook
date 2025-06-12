using AddressBook.Shared.DTOs.Contact;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.Validation
{
    public class ContactWriteDtoValidator : AbstractValidator<ContactWriteDto>
    {
        public ContactWriteDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name can't be longer than 50 characters.")
                .Matches(@"^[A-ZŻŹĆĄŚĘŁÓŃ][a-zżźćńółęąś]{1,49}$")
                .WithMessage("First name must start with a capital letter and contain only letters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name can't be longer than 50 characters.")
                .Matches(@"^[A-ZŻŹĆĄŚĘŁÓŃ][a-zżźćńółęąś]{1,49}(-[A-ZŻŹĆĄŚĘŁÓŃ][a-zżźćńółęąś]{1,49})?$")
                .WithMessage("Last name must start with a capital letter and may contain a hyphenated part.");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Birth date is required.")
                .LessThan(DateTime.Today).WithMessage("Birth date must be in the past.")
                .GreaterThan(DateTime.Today.AddYears(-120)).WithMessage("Birth date is too far in the past.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20).WithMessage("Phone number can't be longer than 20 characters.")
                .Matches(@"^\+?[0-9\s-]{7,20}$")
                .WithMessage("Phone number can contain only digits, spaces, dashes and optional '+' at the start.");

            RuleFor(x => x.LocationId)
                .GreaterThan(0).WithMessage("You must select a valid location.");
        }
    }
}
