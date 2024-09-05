using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Orders.Queries.GetById;

public class GetByIdOrderResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AddressId { get; set; }
    public string? Shipping { get; set; }

}