using NArchitecture.Core.Application.Responses;

namespace Application.Features.PrintAreas.Commands.Delete;

public class DeletedPrintAreaResponse : IResponse
{
    public Guid Id { get; set; }
}