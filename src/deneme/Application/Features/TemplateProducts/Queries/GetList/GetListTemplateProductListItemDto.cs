using Domain.Entities;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Security.Entities;

namespace Application.Features.TemplateProducts.Queries.GetList;

public class GetListTemplateProductListItemDto : IDto
{
    public Guid Id { get; set; }
    public int OrderCount { get; set; }
    public Guid OrderItemId { get; set; }
    public Guid UserId { get; set; }
}