using NArchitecture.Core.Application.Responses;

namespace Application.Features.Options.Commands.Update;

public class UpdatedOptionResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}