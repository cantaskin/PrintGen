using FluentValidation;

namespace Application.Features.CustomizedImages.Commands.Delete;

public class DeleteCustomizedImageCommandValidator : AbstractValidator<DeleteCustomizedImageCommand>
{
    public DeleteCustomizedImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}