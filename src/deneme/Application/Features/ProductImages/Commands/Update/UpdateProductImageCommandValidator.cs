using FluentValidation;

namespace Application.Features.ProductImages.Commands.Update;

public class UpdateProductImageCommandValidator : AbstractValidator<UpdateProductImageCommand>
{
    public UpdateProductImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
    }
}