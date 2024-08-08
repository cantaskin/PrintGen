using NArchitecture.Core.Application.Responses;

namespace Application.Features.Orders.Commands.Create;

public class CreatedOrderResponse : IResponse
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public Guid StatusId { get; set; }
    public Guid UserId { get; set; }
    public Guid AddressId { get; set; }
}