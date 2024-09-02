using FluentValidation;

namespace Application.Features.RetailCosts.Commands.Create;

public class CreateRetailCostCommandValidator : AbstractValidator<CreateRetailCostCommand>
{
    public CreateRetailCostCommandValidator()
    {
        RuleFor(c => c.Currency).NotEmpty();
        RuleFor(c => c.Discount).NotEmpty();
        RuleFor(c => c.Shipping).NotEmpty();
        RuleFor(c => c.Tax).NotEmpty();
    }
}