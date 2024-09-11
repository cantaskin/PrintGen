using NArchitecture.Core.Application.Dtos;

namespace Application.Features.TemplateProducts.Queries.GetList;

public class GetListTemplateProductListItemDto : IDto
{
    public Guid Id { get; set; }
    public int OrderCount { get; set; }
    public Guid OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}