using Application.Features.Layers.Commands.Create;
using Application.Features.Layers.Commands.Delete;
using Application.Features.Layers.Commands.Update;
using Application.Features.Layers.Queries.GetById;
using Application.Features.Layers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Layers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateLayerCommand, Layer>();
        CreateMap<Layer, CreatedLayerResponse>();

        CreateMap<UpdateLayerCommand, Layer>();
        CreateMap<Layer, UpdatedLayerResponse>();

        CreateMap<DeleteLayerCommand, Layer>();
        CreateMap<Layer, DeletedLayerResponse>();

        CreateMap<Layer, GetByIdLayerResponse>();

        CreateMap<Layer, GetListLayerListItemDto>();
        CreateMap<IPaginate<Layer>, GetListResponse<GetListLayerListItemDto>>();
    }
}