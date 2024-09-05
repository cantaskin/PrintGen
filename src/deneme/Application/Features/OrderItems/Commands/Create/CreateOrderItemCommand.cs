using Application.Features.OrderItems.Rules;
using Application.Features.Placements.Commands.Create;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderItems.Commands.Create;

public class CreateOrderItemCommand : IRequest<CreatedOrderItemResponse>
{
    public required string Source { get; set; }
    public required int CatalogVariantId { get; set; }
    public string? ExternalId { get; set; }
    public required int Quantity { get; set; }
    public string? RetailPrice { get; set; }
    public string? Name { get; set; }

    //public required Guid PlacementId { get; set; }
    public required List<CreatePlacementCommand> Placements { get; set; }


    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, CreatedOrderItemResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly OrderItemBusinessRules _orderItemBusinessRules;

        public CreateOrderItemCommandHandler(IMapper mapper, IOrderItemRepository orderItemRepository,
                                         OrderItemBusinessRules orderItemBusinessRules)
        {
            _mapper = mapper;
            _orderItemRepository = orderItemRepository;
            _orderItemBusinessRules = orderItemBusinessRules;
        }

        public async Task<CreatedOrderItemResponse> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            OrderItem orderItem = _mapper.Map<OrderItem>(request);

            await _orderItemRepository.AddAsync(orderItem);

            CreatedOrderItemResponse response = _mapper.Map<CreatedOrderItemResponse>(orderItem);
            return response;
        }
    }
}