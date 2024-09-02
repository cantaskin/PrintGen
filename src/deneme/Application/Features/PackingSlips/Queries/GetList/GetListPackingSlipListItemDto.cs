using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PackingSlips.Queries.GetList;

public class GetListPackingSlipListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }
    public string LogoUrl { get; set; }
    public string StoreName { get; set; }
    public string CustomerOrderId { get; set; }
}