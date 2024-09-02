using Application.Features.Customizations.Commands.Create;
using Application.Features.Customizations.Commands.Delete;
using Application.Features.Customizations.Commands.Update;
using Application.Features.Customizations.Queries.GetById;
using Application.Features.Customizations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Customizations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCustomizationCommand, Customization>();
        CreateMap<Customization, CreatedCustomizationResponse>();

        CreateMap<UpdateCustomizationCommand, Customization>();
        CreateMap<Customization, UpdatedCustomizationResponse>();

        CreateMap<DeleteCustomizationCommand, Customization>();
        CreateMap<Customization, DeletedCustomizationResponse>();

        CreateMap<Customization, GetByIdCustomizationResponse>();

        CreateMap<Customization, GetListCustomizationListItemDto>();
        CreateMap<IPaginate<Customization>, GetListResponse<GetListCustomizationListItemDto>>();
    }
}