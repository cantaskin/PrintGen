using NArchitecture.Core.Application.Dtos;

namespace Application.Features.OrderTransports.Queries.GetList;

public class GetListOrderTransportListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}