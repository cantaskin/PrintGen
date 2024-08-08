using NArchitecture.Core.Application.Responses;

namespace Application.Features.Prompts.Commands.Delete;

public class DeletedPromptResponse : IResponse
{
    public Guid Id { get; set; }
}