using FluentValidation;

namespace Application.Features.Customizations.Commands.Update;

public class UpdateCustomizationCommandValidator : AbstractValidator<UpdateCustomizationCommand>
{
    public UpdateCustomizationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PackingSlipId).NotEmpty();
    }
}