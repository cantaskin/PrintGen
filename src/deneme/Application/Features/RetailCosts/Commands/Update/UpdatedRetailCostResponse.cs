using NArchitecture.Core.Application.Responses;

namespace Application.Features.RetailCosts.Commands.Update;

public class UpdatedRetailCostResponse : IResponse
{
    public Guid Id { get; set; }
    public string Currency { get; set; }
    public string Discount { get; set; }
    public string Shipping { get; set; }
    public string Tax { get; set; }
}