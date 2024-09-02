using FluentValidation;

namespace Application.Features.Layers.Commands.Delete;

public class DeleteLayerCommandValidator : AbstractValidator<DeleteLayerCommand>
{
    public DeleteLayerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}