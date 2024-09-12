using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TemplateProducts.Command.Update;
public class UpdateTemplateProductCommandValidator : AbstractValidator<UpdateTemplateProductCommand>
{
    public UpdateTemplateProductCommandValidator()
    {
        RuleFor(tp => tp.Id).NotEmpty();
        RuleFor(tp => tp.Id).NotEmpty();
        RuleFor(tp => tp.Id).NotEmpty();
    }
}
