using NArchitecture.Core.Application.Responses;

namespace Application.Features.Gifts.Commands.Delete;

public class DeletedGiftResponse : IResponse
{
    public Guid Id { get; set; }
}