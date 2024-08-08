using Application.Features.OrderDetails.Commands.Create;
using Application.Features.OrderDetails.Commands.Delete;
using Application.Features.OrderDetails.Commands.Update;
using Application.Features.OrderDetails.Queries.GetById;
using Application.Features.OrderDetails.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.OrderDetails.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateOrderDetailCommand, OrderDetail>();
        CreateMap<OrderDetail, CreatedOrderDetailResponse>();

        CreateMap<UpdateOrderDetailCommand, OrderDetail>();
        CreateMap<OrderDetail, UpdatedOrderDetailResponse>();

        CreateMap<DeleteOrderDetailCommand, OrderDetail>();
        CreateMap<OrderDetail, DeletedOrderDetailResponse>();

        CreateMap<OrderDetail, GetByIdOrderDetailResponse>();

        CreateMap<OrderDetail, GetListOrderDetailListItemDto>();
        CreateMap<IPaginate<OrderDetail>, GetListResponse<GetListOrderDetailListItemDto>>();
    }
}