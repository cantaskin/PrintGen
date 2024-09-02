using FluentValidation;

namespace Application.Features.RetailCosts.Commands.Delete;

public class DeleteRetailCostCommandValidator : AbstractValidator<DeleteRetailCostCommand>
{
    public DeleteRetailCostCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}