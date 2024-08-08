using FluentValidation;

namespace Application.Features.Prompts.Commands.Delete;

public class DeletePromptCommandValidator : AbstractValidator<DeletePromptCommand>
{
    public DeletePromptCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}