using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CustomizedImages.Queries.GetList;

public class GetListCustomizedImageListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? ImageUrl { get; set; }
    public Guid PromptId { get; set; }
}