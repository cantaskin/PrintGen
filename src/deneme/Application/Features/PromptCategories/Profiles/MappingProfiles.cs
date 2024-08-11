using Application.Features.PromptCategories.Commands.Create;
using Application.Features.PromptCategories.Commands.Delete;
using Application.Features.PromptCategories.Commands.Update;
using Application.Features.PromptCategories.Queries.GetById;
using Application.Features.PromptCategories.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PromptCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePromptCategoryCommand, PromptCategory>();
        CreateMap<PromptCategory, CreatedPromptCategoryResponse>();

        CreateMap<UpdatePromptCategoryCommand, PromptCategory>();
        CreateMap<PromptCategory, UpdatedPromptCategoryResponse>();

        CreateMap<DeletePromptCategoryCommand, PromptCategory>();
        CreateMap<PromptCategory, DeletedPromptCategoryResponse>();

        CreateMap<PromptCategory, GetByIdPromptCategoryResponse>();

        CreateMap<PromptCategory, GetListPromptCategoryListItemDto>();
        CreateMap<IPaginate<PromptCategory>, GetListResponse<GetListPromptCategoryListItemDto>>();
    }
}