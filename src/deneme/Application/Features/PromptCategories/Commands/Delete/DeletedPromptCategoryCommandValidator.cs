using FluentValidation;

namespace Application.Features.PromptCategories.Commands.Delete;

public class DeletePromptCategoryCommandValidator : AbstractValidator<DeletePromptCategoryCommand>
{
    public DeletePromptCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}