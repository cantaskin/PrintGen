using NArchitecture.Core.Application.Responses;
using System.Drawing;

namespace Application.Features.PrintAreas.Commands.Update;

public class UpdatedPrintAreaResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid PrintAreaNameId { get; set; }
    public Guid ProductId { get; set; }
    public Guid? CustomizedImageId { get; set; }
    public int X { get; set; }

    public int Y { get; set; }
}