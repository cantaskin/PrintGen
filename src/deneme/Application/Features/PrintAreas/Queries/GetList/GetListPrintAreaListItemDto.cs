using NArchitecture.Core.Application.Dtos;
using System.Drawing;

namespace Application.Features.PrintAreas.Queries.GetList;

public class GetListPrintAreaListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid PrintAreaNameId { get; set; }
    public Guid ProductId { get; set; }
    public Guid? CustomizedImageId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}