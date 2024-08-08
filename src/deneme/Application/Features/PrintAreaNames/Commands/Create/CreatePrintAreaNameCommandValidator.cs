using FluentValidation;

namespace Application.Features.PrintAreaNames.Commands.Create;

public class CreatePrintAreaNameCommandValidator : AbstractValidator<CreatePrintAreaNameCommand>
{
    public CreatePrintAreaNameCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}