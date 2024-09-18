using Domain.Entities;
using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TemplateProducts.Queries.GetDynamicList;
public class GetDynamicListTemplateProductListItemDto : IDto
{
    public Guid Id { get; set; }
    public int OrderCount { get; set; }
    public Guid OrderItemId { get; set; }
    public Guid UserId { get; set; }
}
