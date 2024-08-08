using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductImages.Queries.GetById;

public class GetByIdProductImageResponse : IResponse
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public Guid ProductId { get; set; }
}