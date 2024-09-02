using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Positions.Queries.GetList;

public class GetListPositionListItemDto : IDto
{
    public Guid Id { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Top { get; set; }
    public float Left { get; set; }
}