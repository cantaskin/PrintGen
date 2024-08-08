using FluentValidation;

namespace Application.Features.CustomizedProducts.Commands.Update;

public class UpdateCustomizedProductCommandValidator : AbstractValidator<UpdateCustomizedProductCommand>
{
    public UpdateCustomizedProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.OwnerUserId).NotEmpty();
        RuleFor(c => c.IsPublished).NotEmpty();
    }
}