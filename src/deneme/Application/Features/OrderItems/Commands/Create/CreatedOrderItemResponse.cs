using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderItems.Commands.Create;

public class CreatedOrderItemResponse : IResponse
{
    public Guid Id { get; set; }
    public string Source { get; set; }
    public int CatalogVariantId { get; set; }
    public string? ExternalId { get; set; }
    public int Quantity { get; set; }
    public string? RetailPrice { get; set; }
    public string? Name { get; set; }
    public Guid PlacementId { get; set; }
    public Placement Placement { get; set; }
}