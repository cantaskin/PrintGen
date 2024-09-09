﻿using Application.Features.Auth.Constants;
using Application.Features.Customizations.Commands.Create;
using Application.Features.OrderItems.Commands.Create;
using Application.Features.Orders.Rules;
using Application.Services.Customizations;
using Application.Services.Layers;
using Application.Services.Options;
using Application.Services.OrderItems;
using Application.Services.PackingSlips;
using Application.Services.Placements;
using Application.Services.PrintOnDemand;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Transaction;

namespace Application.Features.Orders.Commands.Create;

public class CreateOrderCommand : IRequest<CreatedOrderResponse> , ISecuredRequest, ITransactionalRequest
{
    public required Guid AddressId { get; set; }
    public string? Shipping { get; set; }

    public List<CreateOrderItemCommand> Items { get; set; }

    public CreateCustomizationCommand? Customizations { get; set; }

    public string[] Roles => [AuthOperationClaims.User];

    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreatedOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IPackingSlipService _packingSlipService;


        public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository,
            OrderBusinessRules orderBusinessRules, IPackingSlipService packingSlipService)
        {
            _packingSlipService = packingSlipService;
            _mapper = mapper;
            _orderRepository = orderRepository;
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

                    var layers = _mapper.Map<List<Layer>>(placement.Layers);
                    foreach (var layer in layers)
                    {
                        var layerOptions = _mapper.Map<List<Option>>(layer.LayerOptions);
                        foreach (var layerOption in layerOptions)
                        {
                            layerOption.LayerId = layer.Id;
                        }
                        
                        layer.LayerOptions = layerOptions;

                        layer.PlacementId = placement.Id;
                    }

                    var placementOptions = _mapper.Map<List<Option>>(placement.PlacementOptions);
                    foreach (var placementOption in placementOptions)
                    {
                        placementOption.PlacementId = placementOption.Id;
                    }
                    placement.PlacementOptions = placementOptions;
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

           

            // 4. Eðer varsa, Customization'ý ekle
            if (request.Customizations != null)
            {
                Customization customization = _mapper.Map<Customization>(request.Customizations);

                var gift = _mapper.Map<Gift>(customization.Gift);
                if (gift != null)
                {
                    gift.CustomizationId = customization.Id;
                }

                customization.Gift = gift;

                var packingSlip = _mapper.Map<PackingSlip>(customization.PackingSlip);
                if (packingSlip != null)
                {
                    customization.PackingSlipId = packingSlip.Id;
                }
                else
                {
                    Guid pId = new Guid("6ad7e558-970a-4da4-8059-7bad866c700d"); //bunu json dosyasına çekmek lazım.
                    packingSlip = await _packingSlipService.GetAsync(ps => ps.Id == pId);
                }
                customization.PackingSlip = packingSlip;


                customization.OrderId = order.Id;
               // await _customizationService.AddAsync(customization);
                
               order.Customization = customization;
            }

            await _orderRepository.AddAsync(order);

            // 5. Yanýtý oluþtur ve dön
            CreatedOrderResponse response = _mapper.Map<CreatedOrderResponse>(order);
            return response;

    }
        }


}