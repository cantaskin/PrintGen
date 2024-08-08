using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductImages.Commands.Delete;

public class DeletedProductImageResponse : IResponse
{
    public Guid Id { get; set; }
}