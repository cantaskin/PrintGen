using FluentValidation;

namespace Application.Features.PromptCategories.Commands.Create;

public class CreatePromptCategoryCommandValidator : AbstractValidator<CreatePromptCategoryCommand>
{
    public CreatePromptCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}