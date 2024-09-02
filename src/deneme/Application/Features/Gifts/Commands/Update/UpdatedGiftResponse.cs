using NArchitecture.Core.Application.Responses;

namespace Application.Features.Gifts.Commands.Update;

public class UpdatedGiftResponse : IResponse
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}