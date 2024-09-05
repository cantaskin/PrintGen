using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Orders.Commands.Update;

public class UpdatedOrderResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public string? Shipping { get; set; }
}