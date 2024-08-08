using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.OrderTransports.Queries.GetList;

public class GetListOrderTransportQuery : IRequest<GetListResponse<GetListOrderTransportListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListOrderTransportQueryHandler : IRequestHandler<GetListOrderTransportQuery, GetListResponse<GetListOrderTransportListItemDto>>
    {
        private readonly IOrderTransportRepository _orderTransportRepository;
        private readonly IMapper _mapper;

        public GetListOrderTransportQueryHandler(IOrderTransportRepository orderTransportRepository, IMapper mapper)
        {
            _orderTransportRepository = orderTransportRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListOrderTransportListItemDto>> Handle(GetListOrderTransportQuery request, CancellationToken cancellationToken)
        {
            IPaginate<OrderTransport> orderTransports = await _orderTransportRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListOrderTransportListItemDto> response = _mapper.Map<GetListResponse<GetListOrderTransportListItemDto>>(orderTransports);
            return response;
        }
    }
}