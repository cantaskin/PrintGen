using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TemplateProducts.Command.Create;
public class CreateTemplateProductCommandValidator : AbstractValidator<CreateTemplateProductCommand>
{
    public CreateTemplateProductCommandValidator()
    {
        RuleFor(tp => tp.UserId).NotEmpty();
        RuleFor(tp => tp.OrderItemId).NotEmpty();
    }
}
