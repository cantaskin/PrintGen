using Application.Features.OrderTransports.Constants;
using Application.Features.OrderTransports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderTransports.Commands.Delete;

public class DeleteOrderTransportCommand : IRequest<DeletedOrderTransportResponse>
{
    public Guid Id { get; set; }

    public class DeleteOrderTransportCommandHandler : IRequestHandler<DeleteOrderTransportCommand, DeletedOrderTransportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderTransportRepository _orderTransportRepository;
        private readonly OrderTransportBusinessRules _orderTransportBusinessRules;

        public DeleteOrderTransportCommandHandler(IMapper mapper, IOrderTransportRepository orderTransportRepository,
                                         OrderTransportBusinessRules orderTransportBusinessRules)
        {
            _mapper = mapper;
            _orderTransportRepository = orderTransportRepository;
            _orderTransportBusinessRules = orderTransportBusinessRules;
        }

        public async Task<DeletedOrderTransportResponse> Handle(DeleteOrderTransportCommand request, CancellationToken cancellationToken)
        {
            OrderTransport? orderTransport = await _orderTransportRepository.GetAsync(predicate: ot => ot.Id == request.Id, cancellationToken: cancellationToken);
            await _orderTransportBusinessRules.OrderTransportShouldExistWhenSelected(orderTransport);

            await _orderTransportRepository.DeleteAsync(orderTransport!);

            DeletedOrderTransportResponse response = _mapper.Map<DeletedOrderTransportResponse>(orderTransport);
            return response;
        }
    }
}