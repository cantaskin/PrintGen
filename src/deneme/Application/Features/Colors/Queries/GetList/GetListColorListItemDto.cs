using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Colors.Queries.GetList;

public class GetListColorListItemDto : IDto
{
    public Guid Id { get; set; }
    public string ColorName { get; set; }
    public Product Product { get; set; }
}