using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.OrderItems.Queries.GetList;

public class GetListOrderItemListItemDto : IDto
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