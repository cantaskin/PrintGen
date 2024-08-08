using Application.Features.OrderDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderDetails.Commands.Update;

public class UpdateOrderDetailCommand : IRequest<UpdatedOrderDetailResponse>
{
    public Guid Id { get; set; }
    public required Guid CustomizedProductId { get; set; }
    public required float Price { get; set; }
    public required int Quantity { get; set; }
    public required int Discount { get; set; }

    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, UpdatedOrderDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly OrderDetailBusinessRules _orderDetailBusinessRules;

        public UpdateOrderDetailCommandHandler(IMapper mapper, IOrderDetailRepository orderDetailRepository,
                                         OrderDetailBusinessRules orderDetailBusinessRules)
        {
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
            _orderDetailBusinessRules = orderDetailBusinessRules;
        }

        public async Task<UpdatedOrderDetailResponse> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            OrderDetail? orderDetail = await _orderDetailRepository.GetAsync(predicate: od => od.Id == request.Id, cancellationToken: cancellationToken);
            await _orderDetailBusinessRules.OrderDetailShouldExistWhenSelected(orderDetail);
            orderDetail = _mapper.Map(request, orderDetail);

            await _orderDetailRepository.UpdateAsync(orderDetail!);

            UpdatedOrderDetailResponse response = _mapper.Map<UpdatedOrderDetailResponse>(orderDetail);
            return response;
        }
    }
}