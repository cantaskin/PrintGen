using FluentValidation;

namespace Application.Features.Gifts.Commands.Delete;

public class DeleteGiftCommandValidator : AbstractValidator<DeleteGiftCommand>
{
    public DeleteGiftCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}