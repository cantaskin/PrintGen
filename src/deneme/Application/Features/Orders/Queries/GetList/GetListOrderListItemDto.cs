using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Orders.Queries.GetList;

public class GetListOrderListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public Guid RetailCostId { get; set; }
    public Guid? CustomizationId { get; set; }
    public string? Shipping { get; set; }
    public Customization? Customization { get; set; }
    public Address Address { get; set; }
    public RetailCost? RetailCost { get; set; }
}