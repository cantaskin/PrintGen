using Application.Features.TemplateProducts.Command.Create;
using Application.Features.TemplateProducts.Command.Delete;
using Application.Features.TemplateProducts.Command.Update;
using Application.Features.TemplateProducts.Queries.GetById;
using Application.Features.TemplateProducts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.TemplateProducts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTemplateProductCommand, TemplateProduct>();
        CreateMap<TemplateProduct, CreatedTemplateProductResponse>();

        CreateMap<UpdateTemplateProductCommand, TemplateProduct>();
        CreateMap<TemplateProduct, UpdatedTemplateProductResponse>();

        CreateMap<DeleteTemplateProductCommand, TemplateProduct>();
        CreateMap<TemplateProduct, DeletedTemplateProductResponse>();

        CreateMap<TemplateProduct, GetByIdTemplateProductResponse>();

        CreateMap<TemplateProduct, GetListTemplateProductListItemDto>();
        CreateMap<IPaginate<TemplateProduct>, GetListResponse<GetListTemplateProductListItemDto>>();
    }
}