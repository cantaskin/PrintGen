using NArchitecture.Core.Application.Responses;

namespace Application.Features.RetailCosts.Commands.Delete;

public class DeletedRetailCostResponse : IResponse
{
    public Guid Id { get; set; }
}