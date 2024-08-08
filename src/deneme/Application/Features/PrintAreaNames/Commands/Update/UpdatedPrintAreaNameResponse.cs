using NArchitecture.Core.Application.Responses;

namespace Application.Features.PrintAreaNames.Commands.Update;

public class UpdatedPrintAreaNameResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}