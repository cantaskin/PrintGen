using NArchitecture.Core.Application.Responses;

namespace Application.Features.Placements.Commands.Delete;

public class DeletedPlacementResponse : IResponse
{
    public Guid Id { get; set; }
}