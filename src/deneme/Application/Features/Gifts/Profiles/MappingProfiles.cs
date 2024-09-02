using Application.Features.Gifts.Commands.Create;
using Application.Features.Gifts.Commands.Delete;
using Application.Features.Gifts.Commands.Update;
using Application.Features.Gifts.Queries.GetById;
using Application.Features.Gifts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Gifts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateGiftCommand, Gift>();
        CreateMap<Gift, CreatedGiftResponse>();

        CreateMap<UpdateGiftCommand, Gift>();
        CreateMap<Gift, UpdatedGiftResponse>();

        CreateMap<DeleteGiftCommand, Gift>();
        CreateMap<Gift, DeletedGiftResponse>();

        CreateMap<Gift, GetByIdGiftResponse>();

        CreateMap<Gift, GetListGiftListItemDto>();
        CreateMap<IPaginate<Gift>, GetListResponse<GetListGiftListItemDto>>();
    }
}