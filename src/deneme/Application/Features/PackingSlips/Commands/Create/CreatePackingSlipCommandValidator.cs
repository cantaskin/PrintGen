using FluentValidation;

namespace Application.Features.PackingSlips.Commands.Create;

public class CreatePackingSlipCommandValidator : AbstractValidator<CreatePackingSlipCommand>
{
    public CreatePackingSlipCommandValidator()
    {
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.LogoUrl).NotEmpty();
        RuleFor(c => c.StoreName).NotEmpty();
        RuleFor(c => c.CustomerOrderId).NotEmpty();
    }
}