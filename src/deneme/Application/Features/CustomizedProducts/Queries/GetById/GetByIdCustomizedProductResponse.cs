using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomizedProducts.Queries.GetById;

public class GetByIdCustomizedProductResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid OwnerUserId { get; set; }
    public bool IsPublished { get; set; }
}