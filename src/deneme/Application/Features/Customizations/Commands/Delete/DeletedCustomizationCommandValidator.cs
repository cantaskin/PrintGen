using FluentValidation;

namespace Application.Features.Customizations.Commands.Delete;

public class DeleteCustomizationCommandValidator : AbstractValidator<DeleteCustomizationCommand>
{
    public DeleteCustomizationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}