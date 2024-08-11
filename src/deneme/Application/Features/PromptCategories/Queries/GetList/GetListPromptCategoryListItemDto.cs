using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PromptCategories.Queries.GetList;

public class GetListPromptCategoryListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}