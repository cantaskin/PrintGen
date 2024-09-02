using FluentValidation;

namespace Application.Features.Gifts.Commands.Create;

public class CreateGiftCommandValidator : AbstractValidator<CreateGiftCommand>
{
    public CreateGiftCommandValidator()
    {
        RuleFor(c => c.Subject).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
    }
}