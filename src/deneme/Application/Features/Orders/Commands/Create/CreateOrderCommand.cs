using Application.Features.Customizations.Commands.Create;
using Application.Features.OrderItems.Commands.Create;
using Application.Features.Orders.Rules;
using Application.Services.Customizations;
using Application.Services.OrderItems;
using Application.Services.Placements;
using Application.Services.PrintOnDemand;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Orders.Commands.Create;

public class CreateOrderCommand : IRequest<CreatedOrderResponse>
{
    public required Guid AddressId { get; set; }
    public string? Shipping { get; set; }

    public List<CreateOrderItemCommand> Items { get; set; }

    public CreateCustomizationCommand? Customizations { get; set; }

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreatedOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly OrderBusinessRules _orderBusinessRules;
        private readonly IOrderItemService _orderItemService;
        private readonly ICustomizationService _customizationService;
        private readonly IPlacementService _placementService;

        public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository,
                                         OrderBusinessRules orderBusinessRules,IOrderItemService _itemService, ICustomizationService customizationService, IPlacementService placementService)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _orderBusinessRules = orderBusinessRules;
            _orderItemService = _itemService;
            _customizationService = customizationService;
            _placementService = placementService;
        }

        public async Task<CreatedOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = _mapper.Map<Order>(request);
            order.OrderItems = new List<OrderItem>();

            foreach (var item in request.Items)
            {
                var orderItem = _mapper.Map<OrderItem>(item);
                order.OrderItems.Add(orderItem);

                var placements = _mapper.Map<List<Placement>>(item.Placements);
                foreach (var placement in placements)
                {
                    placement.OrderItemId = orderItem.Id;
                }
                orderItem.Placements = placements;
            }

            await _orderRepository.AddAsync(order);

            // 4. Eðer varsa, Customization'ý ekle
            if (request.Customizations != null)
            {
                Customization customization = _mapper.Map<Customization>(request.Customizations);
                customization.OrderId = order.Id;
                await _customizationService.AddAsync(customization);
            }

            // 5. Yanýtý oluþtur ve dön
            CreatedOrderResponse response = _mapper.Map<CreatedOrderResponse>(order);
            return response;
        }
    }
}