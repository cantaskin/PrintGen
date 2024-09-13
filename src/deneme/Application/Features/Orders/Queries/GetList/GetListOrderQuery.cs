using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Security.Constants;

namespace Application.Features.Orders.Queries.GetList;

public class GetListOrderQuery : IRequest<GetListResponse<GetListdOrderListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [];
    public class GetListOrderQueryHandler : IRequestHandler<GetListOrderQuery, GetListResponse<GetListdOrderListItemDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetListOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListdOrderListItemDto>> Handle(GetListOrderQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Order> orders = await _orderRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListdOrderListItemDto> response = _mapper.Map<GetListResponse<GetListdOrderListItemDto>>(orders);
            return response;
        }
    }
}