using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderTransports.Commands.Delete;

public class DeletedOrderTransportResponse : IResponse
{
    public Guid Id { get; set; }
}