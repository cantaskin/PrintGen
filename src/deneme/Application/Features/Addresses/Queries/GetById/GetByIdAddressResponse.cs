using NArchitecture.Core.Application.Responses;

namespace Application.Features.Addresses.Queries.GetById;

public class GetByIdAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
}