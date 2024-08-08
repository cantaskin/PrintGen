using FluentValidation;

namespace Application.Features.PrintAreaNames.Commands.Update;

public class UpdatePrintAreaNameCommandValidator : AbstractValidator<UpdatePrintAreaNameCommand>
{
    public UpdatePrintAreaNameCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}