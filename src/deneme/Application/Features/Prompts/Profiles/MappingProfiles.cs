using Application.Features.Prompts.Commands.Create;
using Application.Features.Prompts.Commands.Delete;
using Application.Features.Prompts.Commands.Update;
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
        CreateMap<CreatePromptCommand, Prompt>();
        CreateMap<Prompt, CreatedPromptResponse>();

        CreateMap<UpdatePromptCommand, Prompt>();
        CreateMap<Prompt, UpdatedPromptResponse>();

        CreateMap<DeletePromptCommand, Prompt>();
        CreateMap<Prompt, DeletedPromptResponse>();

        CreateMap<Prompt, GetByIdPromptResponse>();

        CreateMap<Prompt, GetListPromptListItemDto>();
        CreateMap<IPaginate<Prompt>, GetListResponse<GetListPromptListItemDto>>();
    }
}