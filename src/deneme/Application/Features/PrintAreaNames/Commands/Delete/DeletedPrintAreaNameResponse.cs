using NArchitecture.Core.Application.Responses;

namespace Application.Features.PrintAreaNames.Commands.Delete;

public class DeletedPrintAreaNameResponse : IResponse
{
    public Guid Id { get; set; }
}