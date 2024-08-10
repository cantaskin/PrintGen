using FluentValidation;

namespace Application.Features.CustomizedImages.Commands.Update;

public class UpdateCustomizedImageCommandValidator : AbstractValidator<UpdateCustomizedImageCommand>
{
    public UpdateCustomizedImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PromptId).NotEmpty();
    }
}