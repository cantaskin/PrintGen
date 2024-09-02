using Application.Features.PackingSlips.Commands.Create;
using Application.Features.PackingSlips.Commands.Delete;
using Application.Features.PackingSlips.Commands.Update;
using Application.Features.PackingSlips.Queries.GetById;
using Application.Features.PackingSlips.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PackingSlips.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePackingSlipCommand, PackingSlip>();
        CreateMap<PackingSlip, CreatedPackingSlipResponse>();

        CreateMap<UpdatePackingSlipCommand, PackingSlip>();
        CreateMap<PackingSlip, UpdatedPackingSlipResponse>();

        CreateMap<DeletePackingSlipCommand, PackingSlip>();
        CreateMap<PackingSlip, DeletedPackingSlipResponse>();

        CreateMap<PackingSlip, GetByIdPackingSlipResponse>();

        CreateMap<PackingSlip, GetListPackingSlipListItemDto>();
        CreateMap<IPaginate<PackingSlip>, GetListResponse<GetListPackingSlipListItemDto>>();
    }
}