using NArchitecture.Core.Application.Dtos;

namespace Application.Features.PrintAreaNames.Queries.GetList;

public class GetListPrintAreaNameListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}