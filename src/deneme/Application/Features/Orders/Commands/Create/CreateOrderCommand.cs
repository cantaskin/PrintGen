using Application.Features.Auth.Constants;
using Application.Features.Customizations.Commands.Create;
using Application.Features.OrderItems.Commands.Create;
using Application.Features.Orders.Rules;
using Application.Services.Customizations;
using Application.Services.Layers;
using Application.Services.Options;
using Application.Services.OrderItems;
using Application.Services.PackingSlips;
using Application.Services.Placements;
using Application.Services.PrintfulService;
using Application.Services.PrintOnDemand;
using Application.Services.Repositories;
using Application.Services.TemplateProducts;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Transaction;

namespace Application.Features.Orders.Commands.Create;

public class CreateOrderCommand : IRequest<CreatedOrderResponse>, ISecuredRequest, ITransactionalRequest
{
    public required Guid UserId { get; set; }
    public required Guid AddressId { get; set; }
    public string? Shipping { get; set; }
    public Guid? TemplateProductId { get; set; }
    public List<CreateOrderItemCommand> Items { get; set; }
    public CreateCustomizationCommand? Customizations { get; set; }
    public string[] Roles => new[] { AuthOperationClaims.User };

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreatedOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IPackingSlipService _packingSlipService;
        private readonly Guid _packingSlipId;
        private readonly PrintfulServiceBase _printfulServiceAdapter;
        private readonly ITemplateProductService _templateProductService;

        public CreateOrderCommandHandler(IMapper mapper, ITemplateProductService templateProductService, IOrderRepository orderRepository,
            OrderBusinessRules orderBusinessRules, IPackingSlipService packingSlipService, IConfiguration configuration, PrintfulServiceBase printfulService)
        {
            _mapper = mapper;
            _templateProductService = templateProductService;
            _orderRepository = orderRepository;
            _packingSlipService = packingSlipService;
            _packingSlipId = new Guid(configuration["PackingSlip:Id"]);
            _printfulServiceAdapter = printfulService;
        }

        public async Task<CreatedOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            order.OrderItems = await ProcessOrderItems(request);

            if (request.Customizations != null)
            {
                order.Customization = await ProcessCustomizations(request.Customizations, order.Id);
            }

            await _orderRepository.AddAsync(order);
            await _printfulServiceAdapter.CreateOrderAsync(order.Id);

            return _mapper.Map<CreatedOrderResponse>(order);
        }

        private async Task<List<OrderItem>> ProcessOrderItems(CreateOrderCommand request)
        {
            var orderItems = new List<OrderItem>();

            foreach (var item in request.Items)
            {
                var orderItem = _mapper.Map<OrderItem>(item);
                orderItems.Add(orderItem);

                if (request.TemplateProductId == null)
                {
                    await CreateTemplateProduct(orderItem, request.UserId);
                }
                else
                {
                    await UpdateTemplateProductOrderCount(orderItem,request.UserId);
                }

                await ProcessItemPlacements(item, orderItem);
            }

            return orderItems;
        }

        private async Task CreateTemplateProduct(OrderItem orderItem, Guid userId)
        {
            var templateProduct = new TemplateProduct
            {
                UserId = userId,
                OrderCount = 0,
                CreatedDate = DateTime.Now,
                OrderItemId = orderItem.Id
            };

            orderItem.TemplateProduct = templateProduct;
            //await _templateProductService.AddAsync(templateProduct);
        }

        private async Task UpdateTemplateProductOrderCount(OrderItem orderItem,Guid userId)
        {
            var templateProduct = await _templateProductService.GetAsync(tp => tp.UserId == userId);
            if (templateProduct != null)
            {
                templateProduct.OrderCount++;
                templateProduct.OrderItemId = orderItem.Id;
               // templateProduct.OrderItems.Add(orderItem);
                await _templateProductService.UpdateAsync(templateProduct);
            }
        }

        private async Task ProcessItemPlacements(CreateOrderItemCommand item, OrderItem orderItem)
        {
            var placements = _mapper.Map<List<Placement>>(item.Placements);

            foreach (var placement in placements)
            {
                placement.OrderItemId = orderItem.Id;

                var layers = _mapper.Map<List<Layer>>(placement.Layers);
                foreach (var layer in layers)
                {
                    ProcessLayerOptions(layer);
                    layer.PlacementId = placement.Id;
                }

                ProcessPlacementOptions(placement);
                placement.Layers = layers;
            }

            var productOptions = _mapper.Map<List<Option>>(item.ProductOptions);
            foreach (var productOption in productOptions)
            {
                productOption.OrderItemId = orderItem.Id;
            }

            orderItem.ProductOptions = productOptions;
            orderItem.Placements = placements;
        }

        private void ProcessLayerOptions(Layer layer)
        {
            var layerOptions = _mapper.Map<List<Option>>(layer.LayerOptions);
            foreach (var layerOption in layerOptions)
            {
                layerOption.LayerId = layer.Id;
            }
            layer.LayerOptions = layerOptions;
        }

        private void ProcessPlacementOptions(Placement placement)
        {
            var placementOptions = _mapper.Map<List<Option>>(placement.PlacementOptions);
            foreach (var placementOption in placementOptions)
            {
                placementOption.PlacementId = placement.Id;
            }
            placement.PlacementOptions = placementOptions;
        }

        private async Task<Customization> ProcessCustomizations(CreateCustomizationCommand customizations, Guid orderId)
        {
            var customization = _mapper.Map<Customization>(customizations);

            if (customization.Gift != null)
            {
                customization.Gift.CustomizationId = customization.Id;
            }

            if (customization.PackingSlip != null)
            {
                customization.PackingSlipId = customization.PackingSlip.Id;
            }
            else
            {
                var packingSlip = await _packingSlipService.GetAsync(ps => ps.Id == _packingSlipId);
                customization.PackingSlip = packingSlip;
            }

            customization.OrderId = orderId;
            return customization;
        }
    }
}
