using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomizedImages.Commands.Create;

public class CreatedCustomizedImageRemoveBackgroundResponse : IResponse
{
    public Guid Id { get; set; }
    public string? ImageUrl { get; set; }
    public Guid PromptId { get; set; }
}