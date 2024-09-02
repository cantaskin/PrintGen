using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderItems.Commands.Delete;

public class DeletedOrderItemResponse : IResponse
{
    public Guid Id { get; set; }
}