using FluentValidation;

namespace Application.Features.OrderTransports.Commands.Delete;

public class DeleteOrderTransportCommandValidator : AbstractValidator<DeleteOrderTransportCommand>
{
    public DeleteOrderTransportCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}