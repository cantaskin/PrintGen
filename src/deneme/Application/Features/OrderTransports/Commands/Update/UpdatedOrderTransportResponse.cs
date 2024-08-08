using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderTransports.Commands.Update;

public class UpdatedOrderTransportResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}