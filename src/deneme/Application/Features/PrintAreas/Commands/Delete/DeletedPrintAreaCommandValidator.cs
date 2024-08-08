using FluentValidation;

namespace Application.Features.PrintAreas.Commands.Delete;

public class DeletePrintAreaCommandValidator : AbstractValidator<DeletePrintAreaCommand>
{
    public DeletePrintAreaCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}