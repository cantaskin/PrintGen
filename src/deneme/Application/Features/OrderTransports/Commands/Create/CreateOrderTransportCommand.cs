using Application.Features.OrderTransports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderTransports.Commands.Create;

public class CreateOrderTransportCommand : IRequest<CreatedOrderTransportResponse>
{
    public required string Name { get; set; }

    public class CreateOrderTransportCommandHandler : IRequestHandler<CreateOrderTransportCommand, CreatedOrderTransportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderTransportRepository _orderTransportRepository;
        private readonly OrderTransportBusinessRules _orderTransportBusinessRules;

        public CreateOrderTransportCommandHandler(IMapper mapper, IOrderTransportRepository orderTransportRepository,
                                         OrderTransportBusinessRules orderTransportBusinessRules)
        {
            _mapper = mapper;
            _orderTransportRepository = orderTransportRepository;
            _orderTransportBusinessRules = orderTransportBusinessRules;
        }

        public async Task<CreatedOrderTransportResponse> Handle(CreateOrderTransportCommand request, CancellationToken cancellationToken)
        {
            OrderTransport orderTransport = _mapper.Map<OrderTransport>(request);

            await _orderTransportRepository.AddAsync(orderTransport);

            CreatedOrderTransportResponse response = _mapper.Map<CreatedOrderTransportResponse>(orderTransport);
            return response;
        }
    }
}