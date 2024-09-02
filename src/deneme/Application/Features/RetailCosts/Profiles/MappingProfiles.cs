using Application.Features.RetailCosts.Commands.Create;
using Application.Features.RetailCosts.Commands.Delete;
using Application.Features.RetailCosts.Commands.Update;
using Application.Features.RetailCosts.Queries.GetById;
using Application.Features.RetailCosts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.RetailCosts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateRetailCostCommand, RetailCost>();
        CreateMap<RetailCost, CreatedRetailCostResponse>();

        CreateMap<UpdateRetailCostCommand, RetailCost>();
        CreateMap<RetailCost, UpdatedRetailCostResponse>();

        CreateMap<DeleteRetailCostCommand, RetailCost>();
        CreateMap<RetailCost, DeletedRetailCostResponse>();

        CreateMap<RetailCost, GetByIdRetailCostResponse>();

        CreateMap<RetailCost, GetListRetailCostListItemDto>();
        CreateMap<IPaginate<RetailCost>, GetListResponse<GetListRetailCostListItemDto>>();
    }
}