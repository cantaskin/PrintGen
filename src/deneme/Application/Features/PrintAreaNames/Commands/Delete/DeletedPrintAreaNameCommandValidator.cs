using FluentValidation;

namespace Application.Features.PrintAreaNames.Commands.Delete;

public class DeletePrintAreaNameCommandValidator : AbstractValidator<DeletePrintAreaNameCommand>
{
    public DeletePrintAreaNameCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}