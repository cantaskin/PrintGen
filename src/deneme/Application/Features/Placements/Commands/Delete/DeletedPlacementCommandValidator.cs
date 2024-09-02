using FluentValidation;

namespace Application.Features.Placements.Commands.Delete;

public class DeletePlacementCommandValidator : AbstractValidator<DeletePlacementCommand>
{
    public DeletePlacementCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}