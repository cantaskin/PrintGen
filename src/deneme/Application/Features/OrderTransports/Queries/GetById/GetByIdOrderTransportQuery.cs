using Application.Features.OrderTransports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.OrderTransports.Queries.GetById;

public class GetByIdOrderTransportQuery : IRequest<GetByIdOrderTransportResponse>
{
    public Guid Id { get; set; }

    public class GetByIdOrderTransportQueryHandler : IRequestHandler<GetByIdOrderTransportQuery, GetByIdOrderTransportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderTransportRepository _orderTransportRepository;
        private readonly OrderTransportBusinessRules _orderTransportBusinessRules;

        public GetByIdOrderTransportQueryHandler(IMapper mapper, IOrderTransportRepository orderTransportRepository, OrderTransportBusinessRules orderTransportBusinessRules)
        {
            _mapper = mapper;
            _orderTransportRepository = orderTransportRepository;
            _orderTransportBusinessRules = orderTransportBusinessRules;
        }

        public async Task<GetByIdOrderTransportResponse> Handle(GetByIdOrderTransportQuery request, CancellationToken cancellationToken)
        {
            OrderTransport? orderTransport = await _orderTransportRepository.GetAsync(predicate: ot => ot.Id == request.Id, cancellationToken: cancellationToken);
            await _orderTransportBusinessRules.OrderTransportShouldExistWhenSelected(orderTransport);

            GetByIdOrderTransportResponse response = _mapper.Map<GetByIdOrderTransportResponse>(orderTransport);
            return response;
        }
    }
}