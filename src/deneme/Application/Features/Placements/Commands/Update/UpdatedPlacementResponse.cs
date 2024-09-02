using NArchitecture.Core.Application.Responses;

namespace Application.Features.Placements.Commands.Update;

public class UpdatedPlacementResponse : IResponse
{
    public Guid Id { get; set; }
    public string PlacementName { get; set; }
    public string Technique { get; set; }
    public Guid? PlacementOptionId { get; set; }
}