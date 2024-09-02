using NArchitecture.Core.Application.Responses;

namespace Application.Features.Gifts.Commands.Create;

public class CreatedGiftResponse : IResponse
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}