using Application.Features.OrderItems.Commands.Create;
using Application.Features.OrderItems.Commands.Delete;
using Application.Features.OrderItems.Commands.Update;
using Application.Features.OrderItems.Queries.GetById;
using Application.Features.OrderItems.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.OrderItems.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateOrderItemCommand, OrderItem>();
        CreateMap<OrderItem, CreatedOrderItemResponse>();

        CreateMap<UpdateOrderItemCommand, OrderItem>();
        CreateMap<OrderItem, UpdatedOrderItemResponse>();

        CreateMap<DeleteOrderItemCommand, OrderItem>();
        CreateMap<OrderItem, DeletedOrderItemResponse>();

        CreateMap<OrderItem, GetByIdOrderItemResponse>();

        CreateMap<OrderItem, GetListOrderItemListItemDto>();
        CreateMap<IPaginate<OrderItem>, GetListResponse<GetListOrderItemListItemDto>>();
    }
}