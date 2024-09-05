using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Customizations.Queries.GetList;

public class GetListCustomizationListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid? GiftId { get; set; }
    public Guid PackingSlipId { get; set; }
}