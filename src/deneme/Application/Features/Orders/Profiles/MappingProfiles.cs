using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Commands.Delete;
using Application.Features.Orders.Commands.Update;
using Application.Features.Orders.Queries.GetById;
using Application.Features.Orders.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Orders.Queries.GetListbyUserId;

namespace Application.Features.Orders.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateOrderCommand, Order>();
        CreateMap<Order, CreatedOrderResponse>().ReverseMap();

        CreateMap<UpdateOrderCommand, Order>();
        CreateMap<Order, UpdatedOrderResponse>();


        CreateMap<DeleteOrderCommand, Order>();
        CreateMap<Order, DeletedOrderResponse>();

        CreateMap<Order, GetByIdOrderResponse>();

        CreateMap<Order, GetListbyUserIdOrderListItemDto>();
        CreateMap<IPaginate<Order>, GetListResponse<GetListbyUserIdOrderListItemDto>>();

        CreateMap<Order, GetListdOrderListItemDto>();
        CreateMap<IPaginate<Order>, GetListResponse<GetListdOrderListItemDto>>();

    }
}