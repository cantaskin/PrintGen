using NArchitecture.Core.Application.Responses;

namespace Application.Features.Positions.Queries.GetById;

public class GetByIdPositionResponse : IResponse
{
    public Guid Id { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Top { get; set; }
    public float Left { get; set; }
}