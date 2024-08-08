using Application.Features.CustomizedProducts.Commands.Create;
using Application.Features.CustomizedProducts.Commands.Delete;
using Application.Features.CustomizedProducts.Commands.Update;
using Application.Features.CustomizedProducts.Queries.GetById;
using Application.Features.CustomizedProducts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CustomizedProducts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCustomizedProductCommand, CustomizedProduct>();
        CreateMap<CustomizedProduct, CreatedCustomizedProductResponse>();

        CreateMap<UpdateCustomizedProductCommand, CustomizedProduct>();
        CreateMap<CustomizedProduct, UpdatedCustomizedProductResponse>();

        CreateMap<DeleteCustomizedProductCommand, CustomizedProduct>();
        CreateMap<CustomizedProduct, DeletedCustomizedProductResponse>();

        CreateMap<CustomizedProduct, GetByIdCustomizedProductResponse>();

        CreateMap<CustomizedProduct, GetListCustomizedProductListItemDto>();
        CreateMap<IPaginate<CustomizedProduct>, GetListResponse<GetListCustomizedProductListItemDto>>();
    }
}