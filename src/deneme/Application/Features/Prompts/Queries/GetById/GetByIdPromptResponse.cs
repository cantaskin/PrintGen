using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Prompts.Queries.GetById;

public class GetByIdPromptResponse : IResponse
{
    public Guid Id { get; set; }
    public string PromptString { get; set; }
}