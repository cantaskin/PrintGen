using FluentValidation;

namespace Application.Features.Customizations.Commands.Create;

public class CreateCustomizationCommandValidator : AbstractValidator<CreateCustomizationCommand>
{
    public CreateCustomizationCommandValidator()
    {
        RuleFor(c => c.PackingSlipId).NotEmpty();
    }
}