using Application.Features.RetailCosts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RetailCosts.Commands.Create;

public class CreateRetailCostCommand : IRequest<CreatedRetailCostResponse>
{
    public required string Currency { get; set; }
    public required string Discount { get; set; }
    public required string Shipping { get; set; }
    public required string Tax { get; set; }

    public class CreateRetailCostCommandHandler : IRequestHandler<CreateRetailCostCommand, CreatedRetailCostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRetailCostRepository _retailCostRepository;
        private readonly RetailCostBusinessRules _retailCostBusinessRules;

        public CreateRetailCostCommandHandler(IMapper mapper, IRetailCostRepository retailCostRepository,
                                         RetailCostBusinessRules retailCostBusinessRules)
        {
            _mapper = mapper;
            _retailCostRepository = retailCostRepository;
            _retailCostBusinessRules = retailCostBusinessRules;
        }

        public async Task<CreatedRetailCostResponse> Handle(CreateRetailCostCommand request, CancellationToken cancellationToken)
        {
            RetailCost retailCost = _mapper.Map<RetailCost>(request);

            await _retailCostRepository.AddAsync(retailCost);

            CreatedRetailCostResponse response = _mapper.Map<CreatedRetailCostResponse>(retailCost);
            return response;
        }
    }
}