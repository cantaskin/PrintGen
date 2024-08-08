using NArchitecture.Core.Application.Dtos;

namespace Application.Features.CustomizedProducts.Queries.GetList;

public class GetListCustomizedProductListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid OwnerUserId { get; set; }
    public bool IsPublished { get; set; }
}