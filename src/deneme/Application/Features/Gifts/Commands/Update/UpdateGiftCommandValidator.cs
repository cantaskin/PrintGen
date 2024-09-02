using FluentValidation;

namespace Application.Features.Gifts.Commands.Update;

public class UpdateGiftCommandValidator : AbstractValidator<UpdateGiftCommand>
{
    public UpdateGiftCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Subject).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
    }
}