using NArchitecture.Core.Application.Responses;

namespace Application.Features.Placements.Commands.Create;

public class CreatedPlacementResponse : IResponse
{
    public Guid Id { get; set; }
    public string PlacementName { get; set; }
    public string Technique { get; set; }
    public Guid? PlacementOptionId { get; set; }
}