using NArchitecture.Core.Application.Responses;
using System.Drawing;

namespace Application.Features.CustomizedImages.Commands.Create;

public class CreatedCustomizedImageResponse : IResponse
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; }
    public Guid PrintAreaId { get; set; }
    public string Prompt { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}