using System.Text.RegularExpressions;
using FluentValidation;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c => c.UserForRegisterDto.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.UserForRegisterDto.Password)
            .NotEmpty()
            .MinimumLength(6)
            .Must(StrongPassword)
            .WithMessage(
                "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character."
            );
        RuleFor(c => c.UserForRegisterDto.UserName).NotEmpty().MinimumLength(3);
        RuleFor(c => c.UserForRegisterDto.PhoneNumber).NotEmpty().NotNull().WithMessage("Phone Number is required.")
            .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
            .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
            .WithMessage("PhoneNumber not valid");
    }

    private bool StrongPassword(string value)
    {
        Regex strongPasswordRegex = new("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            RegexOptions.Compiled);

        return strongPasswordRegex.IsMatch(value);
    }
}