using Application.Features.OrderItems.Constants;
using Application.Features.OrderItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderItems.Commands.Delete;

public class DeleteOrderItemCommand : IRequest<DeletedOrderItemResponse>
{
    public Guid Id { get; set; }

    public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, DeletedOrderItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly OrderItemBusinessRules _orderItemBusinessRules;

        public DeleteOrderItemCommandHandler(IMapper mapper, IOrderItemRepository orderItemRepository,
                                         OrderItemBusinessRules orderItemBusinessRules)
        {
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
            _orderItemBusinessRules = orderItemBusinessRules;
        }

        public async Task<DeletedOrderItemResponse> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
        {
            OrderItem? orderItem = await _orderItemRepository.GetAsync(predicate: oi => oi.Id == request.Id, cancellationToken: cancellationToken);
            await _orderItemBusinessRules.OrderItemShouldExistWhenSelected(orderItem);

            await _orderItemRepository.DeleteAsync(orderItem!);

            DeletedOrderItemResponse response = _mapper.Map<DeletedOrderItemResponse>(orderItem);
            return response;
        }
    }
}