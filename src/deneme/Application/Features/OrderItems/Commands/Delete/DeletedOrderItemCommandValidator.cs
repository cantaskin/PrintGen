using FluentValidation;

namespace Application.Features.OrderItems.Commands.Delete;

public class DeleteOrderItemCommandValidator : AbstractValidator<DeleteOrderItemCommand>
{
    public DeleteOrderItemCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}