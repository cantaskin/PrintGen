using NArchitecture.Core.Application.Responses;

namespace Application.Features.CustomizedImages.Queries.GetById;

public class GetByIdCustomizedImageResponse : IResponse
{
    public Guid Id { get; set; }
    public string? ImageUrl { get; set; }
    public Guid PromptId { get; set; }
}