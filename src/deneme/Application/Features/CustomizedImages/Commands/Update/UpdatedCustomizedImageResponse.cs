using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomizedImages.Commands.Update;

public class UpdatedCustomizedImageResponse : IResponse
{
    public Guid Id { get; set; }
    public string? ImageUrl { get; set; }
    public Guid PromptId { get; set; }
}