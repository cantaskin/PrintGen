using FluentValidation;

namespace Application.Features.CustomizedProducts.Commands.Delete;

public class DeleteCustomizedProductCommandValidator : AbstractValidator<DeleteCustomizedProductCommand>
{
    public DeleteCustomizedProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}