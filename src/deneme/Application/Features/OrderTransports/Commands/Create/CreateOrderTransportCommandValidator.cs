using FluentValidation;

namespace Application.Features.OrderTransports.Commands.Create;

public class CreateOrderTransportCommandValidator : AbstractValidator<CreateOrderTransportCommand>
{
    public CreateOrderTransportCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}