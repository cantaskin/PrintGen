using NArchitecture.Core.Application.Dtos;

namespace Application.Features.OrderDetails.Queries.GetList;

public class GetListOrderDetailListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CustomizedProductId { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
    public int Discount { get; set; }
}