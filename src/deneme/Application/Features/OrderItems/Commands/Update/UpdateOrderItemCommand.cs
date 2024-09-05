using Application.Features.OrderItems.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderItems.Commands.Update;

public class UpdateOrderItemCommand : IRequest<UpdatedOrderItemResponse>
{
    public Guid Id { get; set; }
    public required string Source { get; set; }
    public required int CatalogVariantId { get; set; }
    public string? ExternalId { get; set; }
    public required int Quantity { get; set; }
    public string? RetailPrice { get; set; }
    public string? Name { get; set; }
    public required Guid PlacementId { get; set; }

    public required Guid OrderId { get; set; }

    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, UpdatedOrderItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly OrderItemBusinessRules _orderItemBusinessRules;

        public UpdateOrderItemCommandHandler(IMapper mapper, IOrderItemRepository orderItemRepository,
                                         OrderItemBusinessRules orderItemBusinessRules)
        {
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
            _orderItemBusinessRules = orderItemBusinessRules;
        }

        public async Task<UpdatedOrderItemResponse> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            OrderItem? orderItem = await _orderItemRepository.GetAsync(predicate: oi => oi.Id == request.Id, cancellationToken: cancellationToken);
            await _orderItemBusinessRules.OrderItemShouldExistWhenSelected(orderItem);
            orderItem = _mapper.Map(request, orderItem);

            await _orderItemRepository.UpdateAsync(orderItem!);

            UpdatedOrderItemResponse response = _mapper.Map<UpdatedOrderItemResponse>(orderItem);
            return response;
        }
    }
}