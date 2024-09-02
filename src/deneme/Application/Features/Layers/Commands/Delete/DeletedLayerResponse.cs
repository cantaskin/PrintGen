using NArchitecture.Core.Application.Responses;

namespace Application.Features.Layers.Commands.Delete;

public class DeletedLayerResponse : IResponse
{
    public Guid Id { get; set; }
}