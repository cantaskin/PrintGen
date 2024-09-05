using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Layers.Commands.Update;

public class UpdatedLayerResponse : IResponse
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Url { get; set; }
    public Guid? PositionId { get; set; }
}