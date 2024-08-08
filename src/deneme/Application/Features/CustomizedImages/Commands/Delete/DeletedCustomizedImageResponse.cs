using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomizedImages.Commands.Delete;

public class DeletedCustomizedImageResponse : IResponse
{
    public Guid Id { get; set; }
}