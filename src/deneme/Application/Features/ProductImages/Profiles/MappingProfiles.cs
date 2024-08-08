using Application.Features.ProductImages.Commands.Create;
using Application.Features.ProductImages.Commands.Delete;
using Application.Features.ProductImages.Commands.Update;
using Application.Features.ProductImages.Queries.GetById;
using Application.Features.ProductImages.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ProductImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateProductImageCommand, ProductImage>();
        CreateMap<ProductImage, CreatedProductImageResponse>();

        CreateMap<UpdateProductImageCommand, ProductImage>();
        CreateMap<ProductImage, UpdatedProductImageResponse>();

        CreateMap<DeleteProductImageCommand, ProductImage>();
        CreateMap<ProductImage, DeletedProductImageResponse>();

        CreateMap<ProductImage, GetByIdProductImageResponse>();

        CreateMap<ProductImage, GetListProductImageListItemDto>();
        CreateMap<IPaginate<ProductImage>, GetListResponse<GetListProductImageListItemDto>>();
    }
}