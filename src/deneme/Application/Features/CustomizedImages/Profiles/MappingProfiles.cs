using Application.Features.CustomizedImages.Commands.Create;
using Application.Features.CustomizedImages.Commands.Delete;
using Application.Features.CustomizedImages.Commands.Update;
using Application.Features.CustomizedImages.Queries.GetById;
using Application.Features.CustomizedImages.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.CustomizedImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateCustomizedImageCommand, CustomizedImage>();
        CreateMap<CustomizedImage, CreatedCustomizedImageResponse>();

        CreateMap<CreateCustomizedImageRemoveBackgroundCommand, CustomizedImage>();
        CreateMap<CustomizedImage, CreatedCustomizedImageRemoveBackgroundResponse>();

        CreateMap<UpdateCustomizedImageCommand, CustomizedImage>();
        CreateMap<CustomizedImage, UpdatedCustomizedImageResponse>();

        CreateMap<DeleteCustomizedImageCommand, CustomizedImage>();
        CreateMap<CustomizedImage, DeletedCustomizedImageResponse>();

        CreateMap<CustomizedImage, GetByIdCustomizedImageResponse>();

        CreateMap<CustomizedImage, GetListCustomizedImageListItemDto>();
        CreateMap<IPaginate<CustomizedImage>, GetListResponse<GetListCustomizedImageListItemDto>>();
    }
}