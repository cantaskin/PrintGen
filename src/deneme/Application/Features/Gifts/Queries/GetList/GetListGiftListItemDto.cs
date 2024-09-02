using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Gifts.Queries.GetList;

public class GetListGiftListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}