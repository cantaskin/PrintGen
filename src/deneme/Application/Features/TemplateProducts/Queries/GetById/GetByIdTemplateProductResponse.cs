using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.TemplateProducts.Queries.GetById;

public class GetByIdTemplateProductResponse : IResponse
{
    public Guid Id { get; set; }
    public int OrderCount { get; set; }
    public Guid OrderItemId { get; set; }
    public OrderItem OrderItem { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}