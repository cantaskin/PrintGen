using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ProductImages.Queries.GetList;

public class GetListProductImageListItemDto : IDto
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public Guid ProductId { get; set; }
}