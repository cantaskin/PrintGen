using NArchitecture.Core.Application.Responses;

namespace Application.Features.Colors.Commands.Delete;

public class DeletedColorResponse : IResponse
{
    public Guid Id { get; set; }
}