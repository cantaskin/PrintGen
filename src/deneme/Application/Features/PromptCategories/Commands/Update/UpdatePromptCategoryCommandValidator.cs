using FluentValidation;

namespace Application.Features.PromptCategories.Commands.Update;

public class UpdatePromptCategoryCommandValidator : AbstractValidator<UpdatePromptCategoryCommand>
{
    public UpdatePromptCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
    }
}