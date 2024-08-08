using NArchitecture.Core.Application.Responses;

namespace Application.Features.PrintAreaNames.Commands.Create;

public class CreatedPrintAreaNameResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}