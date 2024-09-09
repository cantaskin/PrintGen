using Application.Features.Options.Commands.Create;
using Application.Features.Options.Commands.Delete;
using Application.Features.Options.Commands.Update;
using Application.Features.Options.Queries.GetById;
using Application.Features.Options.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Options.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateOptionCommand, Option>().ReverseMap();
        CreateMap<Option, CreatedOptionResponse>();

        CreateMap<UpdateOptionCommand, Option>();
        CreateMap<Option, UpdatedOptionResponse>();

        CreateMap<DeleteOptionCommand, Option>();
        CreateMap<Option, DeletedOptionResponse>();

        CreateMap<Option, GetByIdOptionResponse>();

        CreateMap<Option, GetListOptionListItemDto>();
        CreateMap<IPaginate<Option>, GetListResponse<GetListOptionListItemDto>>();
    }
}