using NArchitecture.Core.Application.Responses;
using System.Drawing;

namespace Application.Features.CustomizedImages.Queries.GetById;

public class GetByIdCustomizedImageResponse : IResponse
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public Guid PrintAreaId { get; set; }
    public string Prompt { get; set; }
    public required int X { get; set; }
    public required int Y { get; set; }
}