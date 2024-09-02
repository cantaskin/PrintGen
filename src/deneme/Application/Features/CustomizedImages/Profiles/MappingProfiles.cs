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
        CreateMap<CreateCustomizedImageCommand, CustomizedImage>().ReverseMap();
        CreateMap<CustomizedImage, CreatedCustomizedImageResponse>().ReverseMap();

        CreateMap<CreateCustomizedImageRemoveBackgroundCommand, CustomizedImage>().ReverseMap();
        CreateMap<CustomizedImage, CreatedCustomizedImageRemoveBackgroundResponse>().ReverseMap();

        CreateMap<UpdateCustomizedImageCommand, CustomizedImage>().ReverseMap();
        CreateMap<CustomizedImage, UpdatedCustomizedImageResponse>().ReverseMap();

        CreateMap<DeleteCustomizedImageCommand, CustomizedImage>().ReverseMap();
        CreateMap<CustomizedImage, DeletedCustomizedImageResponse>().ReverseMap();

        CreateMap<CustomizedImage, GetByIdCustomizedImageResponse>().ReverseMap();

        CreateMap<CustomizedImage, GetListCustomizedImageListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomizedImage>, GetListResponse<GetListCustomizedImageListItemDto>>().ReverseMap();
    }
}