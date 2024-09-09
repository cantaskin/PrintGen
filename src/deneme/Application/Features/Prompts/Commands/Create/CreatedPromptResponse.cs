using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Prompts.Commands.Create;

public class CreatedPromptResponse : IResponse
{
    public Guid Id { get; set; }
    public string PromptString { get; set; }

    public Guid ImageId { get; set; }
    //public string ImageUrl { get; set; }
}