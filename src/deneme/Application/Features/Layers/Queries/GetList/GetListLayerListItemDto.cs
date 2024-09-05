using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Layers.Queries.GetList;

public class GetListLayerListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }
    public Guid? PositionId { get; set; }
}