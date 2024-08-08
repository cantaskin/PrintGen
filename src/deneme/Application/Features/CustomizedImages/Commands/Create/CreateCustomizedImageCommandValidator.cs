using FluentValidation;

namespace Application.Features.CustomizedImages.Commands.Create;

public class CreateCustomizedImageCommandValidator : AbstractValidator<CreateCustomizedImageCommand>
{
    public CreateCustomizedImageCommandValidator()
    {
        RuleFor(c => c.PrintAreaId).NotEmpty();
        RuleFor(c => c.Prompt).NotEmpty();
        RuleFor(c => c.X).GreaterThan(0);
        RuleFor(c => c.Y).GreaterThan(0);
    }
}