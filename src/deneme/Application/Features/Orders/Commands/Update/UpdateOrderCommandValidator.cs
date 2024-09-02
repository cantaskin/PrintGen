using FluentValidation;

namespace Application.Features.Orders.Commands.Update;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AddressId).NotEmpty();
        RuleFor(c => c.RetailCostId).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
    }
}