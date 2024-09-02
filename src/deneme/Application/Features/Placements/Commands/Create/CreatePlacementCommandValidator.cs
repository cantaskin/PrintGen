using FluentValidation;

namespace Application.Features.Placements.Commands.Create;

public class CreatePlacementCommandValidator : AbstractValidator<CreatePlacementCommand>
{
    public CreatePlacementCommandValidator()
    {
        RuleFor(c => c.PlacementName).NotEmpty();
        RuleFor(c => c.Technique).NotEmpty();
    }
}