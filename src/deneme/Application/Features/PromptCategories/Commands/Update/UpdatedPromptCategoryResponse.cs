using NArchitecture.Core.Application.Responses;

namespace Application.Features.PromptCategories.Commands.Update;

public class UpdatedPromptCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}