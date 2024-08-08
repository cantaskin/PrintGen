using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderTransports.Commands.Create;

public class CreatedOrderTransportResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}