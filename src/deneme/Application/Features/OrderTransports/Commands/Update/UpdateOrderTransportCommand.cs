using Application.Features.OrderTransports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderTransports.Commands.Update;

public class UpdateOrderTransportCommand : IRequest<UpdatedOrderTransportResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public class UpdateOrderTransportCommandHandler : IRequestHandler<UpdateOrderTransportCommand, UpdatedOrderTransportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderTransportRepository _orderTransportRepository;
        private readonly OrderTransportBusinessRules _orderTransportBusinessRules;

        public UpdateOrderTransportCommandHandler(IMapper mapper, IOrderTransportRepository orderTransportRepository,
                                         OrderTransportBusinessRules orderTransportBusinessRules)
        {
            _mapper = mapper;
            _orderTransportRepository = orderTransportRepository;
            _orderTransportBusinessRules = orderTransportBusinessRules;
        }

        public async Task<UpdatedOrderTransportResponse> Handle(UpdateOrderTransportCommand request, CancellationToken cancellationToken)
        {
            OrderTransport? orderTransport = await _orderTransportRepository.GetAsync(predicate: ot => ot.Id == request.Id, cancellationToken: cancellationToken);
            await _orderTransportBusinessRules.OrderTransportShouldExistWhenSelected(orderTransport);
            orderTransport = _mapper.Map(request, orderTransport);

            await _orderTransportRepository.UpdateAsync(orderTransport!);

            UpdatedOrderTransportResponse response = _mapper.Map<UpdatedOrderTransportResponse>(orderTransport);
            return response;
        }
    }
}