using NArchitecture.Core.Application.Dtos;

namespace Application.Features.RetailCosts.Queries.GetList;

public class GetListRetailCostListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Currency { get; set; }
    public string Discount { get; set; }
    public string Shipping { get; set; }
    public string Tax { get; set; }
}