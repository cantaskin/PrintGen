using FluentValidation;

namespace Application.Features.RetailCosts.Commands.Update;

public class UpdateRetailCostCommandValidator : AbstractValidator<UpdateRetailCostCommand>
{
    public UpdateRetailCostCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Currency).NotEmpty();
        RuleFor(c => c.Discount).NotEmpty();
        RuleFor(c => c.Shipping).NotEmpty();
        RuleFor(c => c.Tax).NotEmpty();
    }
}