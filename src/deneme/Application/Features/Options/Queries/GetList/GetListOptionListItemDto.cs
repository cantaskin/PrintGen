using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Options.Queries.GetList;

public class GetListOptionListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}