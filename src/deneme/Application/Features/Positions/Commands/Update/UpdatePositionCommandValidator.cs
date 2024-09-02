using FluentValidation;

namespace Application.Features.Positions.Commands.Update;

public class UpdatePositionCommandValidator : AbstractValidator<UpdatePositionCommand>
{
    public UpdatePositionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Width).NotEmpty();
        RuleFor(c => c.Height).NotEmpty();
        RuleFor(c => c.Top).NotEmpty();
        RuleFor(c => c.Left).NotEmpty();
    }
}