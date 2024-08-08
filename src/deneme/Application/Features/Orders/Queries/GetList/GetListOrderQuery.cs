using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Orders.Queries.GetList;

public class GetListOrderQuery : IRequest<GetListResponse<GetListOrderListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListOrderQueryHandler : IRequestHandler<GetListOrderQuery, GetListResponse<GetListOrderListItemDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetListOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOrderListItemDto>> Handle(GetListOrderQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Order> orders = await _orderRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOrderListItemDto> response = _mapper.Map<GetListResponse<GetListOrderListItemDto>>(orders);
            return response;
        }
    }
}