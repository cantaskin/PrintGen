using FluentValidation;

namespace Application.Features.Customizations.Commands.Create;

public class CreateCustomizationCommandValidator : AbstractValidator<CreateCustomizationCommand>
{
    public CreateCustomizationCommandValidator()
    {
    }
}