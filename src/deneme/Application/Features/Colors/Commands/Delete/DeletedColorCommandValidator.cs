using FluentValidation;

namespace Application.Features.Colors.Commands.Delete;

public class DeleteColorCommandValidator : AbstractValidator<DeleteColorCommand>
{
    public DeleteColorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}