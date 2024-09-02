using FluentValidation;

namespace Application.Features.Placements.Commands.Update;

public class UpdatePlacementCommandValidator : AbstractValidator<UpdatePlacementCommand>
{
    public UpdatePlacementCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PlacementName).NotEmpty();
        RuleFor(c => c.Technique).NotEmpty();
    }
}