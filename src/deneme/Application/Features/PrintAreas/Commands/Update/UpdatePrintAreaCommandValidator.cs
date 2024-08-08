using FluentValidation;

namespace Application.Features.PrintAreas.Commands.Update;

public class UpdatePrintAreaCommandValidator : AbstractValidator<UpdatePrintAreaCommand>
{
    public UpdatePrintAreaCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.PrintAreaNameId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.X).GreaterThan(0).NotEmpty();
        RuleFor(c => c.Y).GreaterThan(0).NotEmpty();
    }
}