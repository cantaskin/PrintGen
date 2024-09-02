using Application.Features.Prompts.Commands.Create;
using Application.Features.Prompts.Commands.Delete;
using Application.Features.Prompts.Queries.GetById;
using Application.Features.Prompts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Prompts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePromptCommand, Prompt>().ReverseMap();
        CreateMap<Prompt, CreatedPromptResponse>().ReverseMap();

        CreateMap<DeletePromptCommand, Prompt>().ReverseMap();
        CreateMap<Prompt, DeletedPromptResponse>().ReverseMap();

        CreateMap<Prompt, GetByIdPromptResponse>().ReverseMap();

        CreateMap<Prompt, GetListPromptListItemDto>().ReverseMap();
        CreateMap<IPaginate<Prompt>, GetListResponse<GetListPromptListItemDto>>().ReverseMap();
    }
}