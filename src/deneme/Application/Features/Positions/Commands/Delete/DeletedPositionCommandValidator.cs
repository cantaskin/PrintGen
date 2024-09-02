using FluentValidation;

namespace Application.Features.Positions.Commands.Delete;

public class DeletePositionCommandValidator : AbstractValidator<DeletePositionCommand>
{
    public DeletePositionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}