using FluentValidation;

namespace Application.Features.Orders.Commands.Update;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Number).NotEmpty();
        RuleFor(c => c.StatusId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.AddressId).NotEmpty();
    }
}