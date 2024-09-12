using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TemplateProducts.Command.Delete;
public class DeleteTemplateProductCommandValidator : AbstractValidator<DeleteTemplateProductCommand>
{
    public DeleteTemplateProductCommandValidator()
    {
        RuleFor(tp => tp.TemplateId).NotEmpty();
    }
}
