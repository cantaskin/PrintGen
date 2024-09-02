using FluentValidation;

namespace Application.Features.Addresses.Commands.Update;

public class UpdateAddressCommandValidator : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Company).NotEmpty();
        RuleFor(c => c.Address1).NotEmpty();
        RuleFor(c => c.Address2).NotEmpty();
        RuleFor(c => c.City).NotEmpty();
        RuleFor(c => c.StateCode).NotEmpty();
        RuleFor(c => c.StateName).NotEmpty();
        RuleFor(c => c.CountryName).NotEmpty();
        RuleFor(c => c.Zip).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
    }
}