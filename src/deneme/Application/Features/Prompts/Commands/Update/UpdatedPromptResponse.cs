using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Prompts.Commands.Update;

public class UpdatedPromptResponse : IResponse
{
    public Guid Id { get; set; }
    public string PromptString { get; set; }
    public CustomizedImage? CustomizedImage { get; set; }
}