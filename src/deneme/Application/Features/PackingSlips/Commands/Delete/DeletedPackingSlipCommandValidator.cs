using FluentValidation;

namespace Application.Features.PackingSlips.Commands.Delete;

public class DeletePackingSlipCommandValidator : AbstractValidator<DeletePackingSlipCommand>
{
    public DeletePackingSlipCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}