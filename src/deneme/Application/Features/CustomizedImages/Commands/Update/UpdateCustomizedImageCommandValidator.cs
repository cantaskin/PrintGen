using FluentValidation;

namespace Application.Features.CustomizedImages.Commands.Update;

public class UpdateCustomizedImageCommandValidator : AbstractValidator<UpdateCustomizedImageCommand>
{
    public UpdateCustomizedImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PrintAreaId).NotEmpty();
        RuleFor(c => c.Prompt).NotEmpty();
        RuleFor(c => c.X).GreaterThan(0);
        RuleFor(c => c.Y).GreaterThan(0);
    }
}