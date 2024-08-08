using FluentValidation;

namespace Application.Features.Orders.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.Number).NotEmpty();
        RuleFor(c => c.StatusId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.AddressId).NotEmpty();
    }
}