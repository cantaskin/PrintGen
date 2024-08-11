using NArchitecture.Core.Application.Responses;

namespace Application.Features.PromptCategories.Commands.Delete;

public class DeletedPromptCategoryResponse : IResponse
{
    public Guid Id { get; set; }
}