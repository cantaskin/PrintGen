using Application.Features.OrderTransports.Commands.Create;
using Application.Features.OrderTransports.Commands.Delete;
using Application.Features.OrderTransports.Commands.Update;
using Application.Features.OrderTransports.Queries.GetById;
using Application.Features.OrderTransports.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.OrderTransports.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateOrderTransportCommand, OrderTransport>();
        CreateMap<OrderTransport, CreatedOrderTransportResponse>();

        CreateMap<UpdateOrderTransportCommand, OrderTransport>();
        CreateMap<OrderTransport, UpdatedOrderTransportResponse>();

        CreateMap<DeleteOrderTransportCommand, OrderTransport>();
        CreateMap<OrderTransport, DeletedOrderTransportResponse>();

        CreateMap<OrderTransport, GetByIdOrderTransportResponse>();

        CreateMap<OrderTransport, GetListOrderTransportListItemDto>();
        CreateMap<IPaginate<OrderTransport>, GetListResponse<GetListOrderTransportListItemDto>>();
    }
}