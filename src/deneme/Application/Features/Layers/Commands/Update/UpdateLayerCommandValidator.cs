using FluentValidation;

namespace Application.Features.Layers.Commands.Update;

public class UpdateLayerCommandValidator : AbstractValidator<UpdateLayerCommand>
{
    public UpdateLayerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Url).NotEmpty();
    }
}