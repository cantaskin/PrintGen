using FluentValidation;

namespace Application.Features.Layers.Commands.Create;

public class CreateLayerCommandValidator : AbstractValidator<CreateLayerCommand>
{
    public CreateLayerCommandValidator()
    {
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Url).NotEmpty();
    }
}