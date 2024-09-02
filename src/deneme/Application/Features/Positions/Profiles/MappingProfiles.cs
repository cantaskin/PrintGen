using Application.Features.Positions.Commands.Create;
using Application.Features.Positions.Commands.Delete;
using Application.Features.Positions.Commands.Update;
using Application.Features.Positions.Queries.GetById;
using Application.Features.Positions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Positions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePositionCommand, Position>();
        CreateMap<Position, CreatedPositionResponse>();

        CreateMap<UpdatePositionCommand, Position>();
        CreateMap<Position, UpdatedPositionResponse>();

        CreateMap<DeletePositionCommand, Position>();
        CreateMap<Position, DeletedPositionResponse>();

        CreateMap<Position, GetByIdPositionResponse>();

        CreateMap<Position, GetListPositionListItemDto>();
        CreateMap<IPaginate<Position>, GetListResponse<GetListPositionListItemDto>>();
    }
}