using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Orders.Queries.GetListbyUserId;

public class GetListbyUserIdOrderListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public string? Shipping { get; set; }
}