using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Orders.Queries.GetList;

public class GetListOrderListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public string? Shipping { get; set; }
}