using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderDetails.Commands.Update;

public class UpdatedOrderDetailResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CustomizedProductId { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
    public int Discount { get; set; }
}