using Application.Features.OrderDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderDetails.Commands.Create;

public class CreateOrderDetailCommand : IRequest<CreatedOrderDetailResponse>
{
    public required Guid CustomizedProductId { get; set; }
    public required float Price { get; set; }
    public required int Quantity { get; set; }
    public required int Discount { get; set; }

    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, CreatedOrderDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly OrderDetailBusinessRules _orderDetailBusinessRules;

        public CreateOrderDetailCommandHandler(IMapper mapper, IOrderDetailRepository orderDetailRepository,
                                         OrderDetailBusinessRules orderDetailBusinessRules)
        {
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
            _orderDetailBusinessRules = orderDetailBusinessRules;
        }

        public async Task<CreatedOrderDetailResponse> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            OrderDetail orderDetail = _mapper.Map<OrderDetail>(request);

            await _orderDetailRepository.AddAsync(orderDetail);

            CreatedOrderDetailResponse response = _mapper.Map<CreatedOrderDetailResponse>(orderDetail);
            return response;
        }
    }
}