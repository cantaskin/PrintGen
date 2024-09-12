using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TemplateProducts.Command.Create;
public class CreatedTemplateProductResponse : IResponse
{
    public Guid Id { get; set; }
}
