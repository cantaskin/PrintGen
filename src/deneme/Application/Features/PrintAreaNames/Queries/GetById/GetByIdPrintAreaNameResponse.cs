using NArchitecture.Core.Application.Responses;

namespace Application.Features.PrintAreaNames.Queries.GetById;

public class GetByIdPrintAreaNameResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}