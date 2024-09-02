using Application.Features.Addresses.Commands.Create;
using Application.Features.Addresses.Commands.Delete;
using Application.Features.Addresses.Commands.Update;
using Application.Features.Addresses.Queries.GetById;
using Application.Features.Addresses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Addresses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateAddressCommand, Address>();
        CreateMap<Address, CreatedAddressResponse>();

        CreateMap<UpdateAddressCommand, Address>();
        CreateMap<Address, UpdatedAddressResponse>();

        CreateMap<DeleteAddressCommand, Address>();
        CreateMap<Address, DeletedAddressResponse>();

        CreateMap<Address, GetByIdAddressResponse>();

        CreateMap<Address, GetListAddressListItemDto>();
        CreateMap<IPaginate<Address>, GetListResponse<GetListAddressListItemDto>>();
    }
}