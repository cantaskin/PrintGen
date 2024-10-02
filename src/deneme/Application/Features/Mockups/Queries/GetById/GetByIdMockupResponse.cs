using NArchitecture.Core.Application.Responses;
using System.Diagnostics;

namespace Application.Features.Mockups.Queries.GetById;

public class GetByIdMockupResponse : IResponse
{
    public string Response { get; set; }
}