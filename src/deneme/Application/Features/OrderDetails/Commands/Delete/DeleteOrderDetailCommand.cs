using Application.Features.OrderDetails.Constants;
using Application.Features.OrderDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderDetails.Commands.Delete;

public class DeleteOrderDetailCommand : IRequest<DeletedOrderDetailResponse>
{
    public Guid Id { get; set; }

    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand, DeletedOrderDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly OrderDetailBusinessRules _orderDetailBusinessRules;

        public DeleteOrderDetailCommandHandler(IMapper mapper, IOrderDetailRepository orderDetailRepository,
                                         OrderDetailBusinessRules orderDetailBusinessRules)
        {
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
            _orderDetailBusinessRules = orderDetailBusinessRules;
        }

        public async Task<DeletedOrderDetailResponse> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
        {
            OrderDetail? orderDetail = await _orderDetailRepository.GetAsync(predicate: od => od.Id == request.Id, cancellationToken: cancellationToken);
            await _orderDetailBusinessRules.OrderDetailShouldExistWhenSelected(orderDetail);

            await _orderDetailRepository.DeleteAsync(orderDetail!);

            DeletedOrderDetailResponse response = _mapper.Map<DeletedOrderDetailResponse>(orderDetail);
            return response;
        }
    }
}