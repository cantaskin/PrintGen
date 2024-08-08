using FluentValidation;

namespace Application.Features.Prompts.Commands.Create;

public class CreatePromptCommandValidator : AbstractValidator<CreatePromptCommand>
{
    public CreatePromptCommandValidator()
    {
        RuleFor(c => c.PromptString).NotEmpty();
    }
}