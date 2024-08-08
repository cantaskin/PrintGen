using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductImages.Commands.Update;

public class UpdatedProductImageResponse : IResponse
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public Guid ProductId { get; set; }
}