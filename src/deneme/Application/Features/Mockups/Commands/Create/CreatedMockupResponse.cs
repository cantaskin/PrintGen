using NArchitecture.Core.Application.Responses;

namespace Application.Features.Mockups.Commands.Create;

public class CreatedMockupResponse : IResponse
{
    public string Response { get; set; }
}