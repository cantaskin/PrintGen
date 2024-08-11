using FluentValidation;

namespace Application.Features.CustomizedImages.Commands.Create;

public class CreateCustomizedImageRemoveBackgroundCommandValidator : AbstractValidator<CreateCustomizedImageCommand>
{
    public CreateCustomizedImageRemoveBackgroundCommandValidator()
    {
        RuleFor(c => c.PromptId).NotEmpty();
    }
}