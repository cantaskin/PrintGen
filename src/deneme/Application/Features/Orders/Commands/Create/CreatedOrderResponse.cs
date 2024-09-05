using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Orders.Commands.Create;

public class CreatedOrderResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public string? Shipping { get; set; }
}