using FluentValidation;

namespace Application.Features.OrderTransports.Commands.Update;

public class UpdateOrderTransportCommandValidator : AbstractValidator<UpdateOrderTransportCommand>
{
    public UpdateOrderTransportCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}