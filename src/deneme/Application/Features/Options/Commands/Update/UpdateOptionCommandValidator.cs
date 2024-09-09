using FluentValidation;

namespace Application.Features.Options.Commands.Update;

public class UpdateOptionCommandValidator : AbstractValidator<UpdateOptionCommand>
{
    public UpdateOptionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Value).NotEmpty();
    }
}