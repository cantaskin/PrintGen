using FluentValidation;

namespace Application.Features.PrintAreas.Commands.Create;

public class CreatePrintAreaCommandValidator : AbstractValidator<CreatePrintAreaCommand>
{
    public CreatePrintAreaCommandValidator()
    {
        RuleFor(c => c.PrintAreaNameId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.X).GreaterThan(0);
        RuleFor(c => c.Y).GreaterThan(0);
    }
}