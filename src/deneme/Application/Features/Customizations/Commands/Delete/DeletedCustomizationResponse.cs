using NArchitecture.Core.Application.Responses;

namespace Application.Features.Customizations.Commands.Delete;

public class DeletedCustomizationResponse : IResponse
{
    public Guid Id { get; set; }
}