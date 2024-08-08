using Application.Features.Colors.Commands.Create;
using Application.Features.Colors.Commands.Delete;
using Application.Features.Colors.Commands.Update;
using Application.Features.Colors.Queries.GetById;
using Application.Features.Colors.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Colors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateColorCommand, Color>();
        CreateMap<Color, CreatedColorResponse>();

        CreateMap<UpdateColorCommand, Color>();
        CreateMap<Color, UpdatedColorResponse>();

        CreateMap<DeleteColorCommand, Color>();
        CreateMap<Color, DeletedColorResponse>();

        CreateMap<Color, GetByIdColorResponse>();

        CreateMap<Color, GetListColorListItemDto>();
        CreateMap<IPaginate<Color>, GetListResponse<GetListColorListItemDto>>();
    }
}