using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.OrderDetails.Queries.GetList;

public class GetListOrderDetailQuery : IRequest<GetListResponse<GetListOrderDetailListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListOrderDetailQueryHandler : IRequestHandler<GetListOrderDetailQuery, GetListResponse<GetListOrderDetailListItemDto>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public GetListOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOrderDetailListItemDto>> Handle(GetListOrderDetailQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OrderDetail> orderDetails = await _orderDetailRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOrderDetailListItemDto> response = _mapper.Map<GetListResponse<GetListOrderDetailListItemDto>>(orderDetails);
            return response;
        }
    }
}