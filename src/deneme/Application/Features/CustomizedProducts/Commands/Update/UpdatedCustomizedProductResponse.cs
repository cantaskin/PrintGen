using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomizedProducts.Commands.Update;

public class UpdatedCustomizedProductResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid OwnerUserId { get; set; }
    public bool IsPublished { get; set; }
}