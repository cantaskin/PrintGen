using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Orders.Queries.GetList;

public class GetListOrderListItemDto : IDto
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public Guid StatusId { get; set; }
    public Guid UserId { get; set; }
    public Guid AddressId { get; set; }
}