using FluentValidation;

namespace Application.Features.Prompts.Commands.Update;

public class UpdatePromptCommandValidator : AbstractValidator<UpdatePromptCommand>
{
    public UpdatePromptCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PromptString).NotEmpty();
    }
}