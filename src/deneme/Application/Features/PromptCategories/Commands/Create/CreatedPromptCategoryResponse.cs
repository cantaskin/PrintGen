using NArchitecture.Core.Application.Responses;

namespace Application.Features.PromptCategories.Commands.Create;

public class CreatedPromptCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}