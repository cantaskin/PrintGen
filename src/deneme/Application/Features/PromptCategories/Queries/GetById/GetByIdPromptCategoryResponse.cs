using NArchitecture.Core.Application.Responses;

namespace Application.Features.PromptCategories.Queries.GetById;

public class GetByIdPromptCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}