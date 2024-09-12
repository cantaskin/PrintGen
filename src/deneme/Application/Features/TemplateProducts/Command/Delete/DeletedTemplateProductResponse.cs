using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TemplateProducts.Command.Delete;
public class DeletedTemplateProductResponse : IResponse
{
    public Guid TemplateId { get; set; }
}
