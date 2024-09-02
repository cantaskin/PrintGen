using FluentValidation;

namespace Application.Features.Positions.Commands.Create;

public class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
{
    public CreatePositionCommandValidator()
    {
        RuleFor(c => c.Width).NotEmpty();
        RuleFor(c => c.Height).NotEmpty();
        RuleFor(c => c.Top).NotEmpty();
        RuleFor(c => c.Left).NotEmpty();
    }
}