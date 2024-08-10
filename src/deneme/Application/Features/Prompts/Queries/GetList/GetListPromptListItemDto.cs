using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Prompts.Queries.GetList;

public class GetListPromptListItemDto : IDto
{
    public Guid Id { get; set; }
    public string PromptString { get; set; }
}