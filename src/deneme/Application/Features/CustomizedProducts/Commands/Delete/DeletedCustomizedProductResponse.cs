using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomizedProducts.Commands.Delete;

public class DeletedCustomizedProductResponse : IResponse
{
    public Guid Id { get; set; }
}