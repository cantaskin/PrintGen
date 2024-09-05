using Application.Features.Placements.Commands.Create;
using Application.Features.Placements.Commands.Delete;
using Application.Features.Placements.Commands.Update;
using Application.Features.Placements.Queries.GetById;
using Application.Features.Placements.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Placements.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePlacementCommand, Placement>();
        CreateMap<Placement, CreatedPlacementResponse>();

        CreateMap<UpdatePlacementCommand, Placement>();
        CreateMap<Placement, UpdatedPlacementResponse>();

        CreateMap<DeletePlacementCommand, Placement>();
        CreateMap<Placement, DeletedPlacementResponse>();

        CreateMap<Placement, GetByIdPlacementResponse>();

        CreateMap<Placement, GetListPlacementListItemDto>();
        CreateMap<IPaginate<Placement>, GetListResponse<GetListPlacementListItemDto>>();


        CreateMap<CreatePlacementCommand, Placement>()
            .ForMember(dest => dest.OrderItemId, opt => opt.Ignore());
    }
}