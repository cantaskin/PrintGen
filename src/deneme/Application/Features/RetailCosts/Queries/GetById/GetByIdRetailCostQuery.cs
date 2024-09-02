using Application.Features.RetailCosts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RetailCosts.Queries.GetById;

public class GetByIdRetailCostQuery : IRequest<GetByIdRetailCostResponse>
{
    public Guid Id { get; set; }

    public class GetByIdRetailCostQueryHandler : IRequestHandler<GetByIdRetailCostQuery, GetByIdRetailCostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRetailCostRepository _retailCostRepository;
        private readonly RetailCostBusinessRules _retailCostBusinessRules;

        public GetByIdRetailCostQueryHandler(IMapper mapper, IRetailCostRepository retailCostRepository, RetailCostBusinessRules retailCostBusinessRules)
        {
            _mapper = mapper;
            _retailCostRepository = retailCostRepository;
            _retailCostBusinessRules = retailCostBusinessRules;
        }

        public async Task<GetByIdRetailCostResponse> Handle(GetByIdRetailCostQuery request, CancellationToken cancellationToken)
        {
            RetailCost? retailCost = await _retailCostRepository.GetAsync(predicate: rc => rc.Id == request.Id, cancellationToken: cancellationToken);
            await _retailCostBusinessRules.RetailCostShouldExistWhenSelected(retailCost);

            GetByIdRetailCostResponse response = _mapper.Map<GetByIdRetailCostResponse>(retailCost);
            return response;
        }
    }
}