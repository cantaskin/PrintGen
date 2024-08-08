using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderTransports.Queries.GetById;

public class GetByIdOrderTransportResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}