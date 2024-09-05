using FluentValidation;

namespace Application.Features.OrderItems.Commands.Create;

public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
{
    public CreateOrderItemCommandValidator()
    {
        RuleFor(c => c.Source).NotEmpty();
        RuleFor(c => c.CatalogVariantId).NotEmpty();
        RuleFor(c => c.Quantity).NotEmpty();
    }
}