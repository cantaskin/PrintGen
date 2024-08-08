using NArchitecture.Core.Application.Responses;

namespace Application.Features.Addresses.Commands.Update;

public class UpdatedAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
}