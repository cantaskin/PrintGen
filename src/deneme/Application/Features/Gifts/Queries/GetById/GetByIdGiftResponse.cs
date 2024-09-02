using NArchitecture.Core.Application.Responses;

namespace Application.Features.Gifts.Queries.GetById;

public class GetByIdGiftResponse : IResponse
{
    public Guid Id { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}