using FluentValidation;

namespace Application.Features.CustomizedImages.Commands.Create;

public class CreateCustomizedImageCommandValidator : AbstractValidator<CreateCustomizedImageCommand>
{
    public CreateCustomizedImageCommandValidator()
    {
        RuleFor(c => c.PromptId).NotEmpty();
    }
}