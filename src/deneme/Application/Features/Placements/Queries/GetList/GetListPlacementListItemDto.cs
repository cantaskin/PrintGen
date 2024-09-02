using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Placements.Queries.GetList;

public class GetListPlacementListItemDto : IDto
{
    public Guid Id { get; set; }
    public string PlacementName { get; set; }
    public string Technique { get; set; }
    public Guid? PlacementOptionId { get; set; }
}