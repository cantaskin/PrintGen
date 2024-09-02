using FluentValidation;

namespace Application.Features.PackingSlips.Commands.Update;

public class UpdatePackingSlipCommandValidator : AbstractValidator<UpdatePackingSlipCommand>
{
    public UpdatePackingSlipCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.LogoUrl).NotEmpty();
        RuleFor(c => c.StoreName).NotEmpty();
        RuleFor(c => c.CustomerOrderId).NotEmpty();
    }
}