using Application.Features.OrderDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderDetails.Queries.GetById;

public class GetByIdOrderDetailQuery : IRequest<GetByIdOrderDetailResponse>
{
    public Guid Id { get; set; }

    public class GetByIdOrderDetailQueryHandler : IRequestHandler<GetByIdOrderDetailQuery, GetByIdOrderDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly OrderDetailBusinessRules _orderDetailBusinessRules;

        public GetByIdOrderDetailQueryHandler(IMapper mapper, IOrderDetailRepository orderDetailRepository, OrderDetailBusinessRules orderDetailBusinessRules)
        {
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
            _orderDetailBusinessRules = orderDetailBusinessRules;
        }

        public async Task<GetByIdOrderDetailResponse> Handle(GetByIdOrderDetailQuery request, CancellationToken cancellationToken)
        {
            OrderDetail? orderDetail = await _orderDetailRepository.GetAsync(predicate: od => od.Id == request.Id, cancellationToken: cancellationToken);
            await _orderDetailBusinessRules.OrderDetailShouldExistWhenSelected(orderDetail);

            GetByIdOrderDetailResponse response = _mapper.Map<GetByIdOrderDetailResponse>(orderDetail);
            return response;
        }
    }
}