using FluentValidation;

namespace Application.Features.CustomizedProducts.Commands.Create;

public class CreateCustomizedProductCommandValidator : AbstractValidator<CreateCustomizedProductCommand>
{
    public CreateCustomizedProductCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.OwnerUserId).NotEmpty();
        RuleFor(c => c.IsPublished).NotEmpty();
    }
}