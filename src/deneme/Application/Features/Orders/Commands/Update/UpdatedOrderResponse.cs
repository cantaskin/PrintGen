using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Orders.Commands.Update;

public class UpdatedOrderResponse : IResponse
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