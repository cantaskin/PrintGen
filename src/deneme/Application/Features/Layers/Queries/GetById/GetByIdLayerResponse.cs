using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Layers.Queries.GetById;

public class GetByIdLayerResponse : IResponse
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }
    public Guid? PositionId { get; set; }
    public Position? Position { get; set; }
}