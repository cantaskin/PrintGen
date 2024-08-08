using FluentValidation;

namespace Application.Features.ProductImages.Commands.Create;

public class CreateProductImageCommandValidator : AbstractValidator<CreateProductImageCommand>
{
    public CreateProductImageCommandValidator()
    {
        RuleFor(c => c.ImageUrl).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
    }
}