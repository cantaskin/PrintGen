using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderItems.Queries.GetById;

public class GetByIdOrderItemResponse : IResponse
{
    public Guid Id { get; set; }
    public string Source { get; set; }
    public int CatalogVariantId { get; set; }
    public string? ExternalId { get; set; }
    public int Quantity { get; set; }
    public string? RetailPrice { get; set; }
    public string? Name { get; set; }
    public Guid PlacementId { get; set; }

}