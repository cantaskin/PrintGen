using NArchitecture.Core.Application.Responses;

namespace Application.Features.Options.Commands.Delete;

public class DeletedOptionResponse : IResponse
{
    public Guid Id { get; set; }
}