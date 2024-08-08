using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductImages.Commands.Create;

public class CreatedProductImageResponse : IResponse
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public Guid ProductId { get; set; }
}