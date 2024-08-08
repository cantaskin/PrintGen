using NArchitecture.Core.Application.Dtos;
using System.Drawing;

namespace Application.Features.CustomizedImages.Queries.GetList;

public class GetListCustomizedImageListItemDto : IDto
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public Guid PrintAreaId { get; set; }
    public string Prompt { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}