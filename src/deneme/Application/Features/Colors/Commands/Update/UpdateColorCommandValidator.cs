using FluentValidation;

namespace Application.Features.Colors.Commands.Update;

public class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
{
    public UpdateColorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ColorName).NotEmpty();
    }
}