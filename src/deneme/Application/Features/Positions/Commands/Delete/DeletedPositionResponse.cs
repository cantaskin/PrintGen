using NArchitecture.Core.Application.Responses;

namespace Application.Features.Positions.Commands.Delete;

public class DeletedPositionResponse : IResponse
{
    public Guid Id { get; set; }
}