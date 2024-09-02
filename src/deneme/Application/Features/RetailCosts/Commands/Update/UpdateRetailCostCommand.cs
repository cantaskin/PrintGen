using Application.Features.RetailCosts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RetailCosts.Commands.Update;

public class UpdateRetailCostCommand : IRequest<UpdatedRetailCostResponse>
{
    public Guid Id { get; set; }
    public required string Currency { get; set; }
    public required string Discount { get; set; }
    public required string Shipping { get; set; }
    public required string Tax { get; set; }

    public class UpdateRetailCostCommandHandler : IRequestHandler<UpdateRetailCostCommand, UpdatedRetailCostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRetailCostRepository _retailCostRepository;
        private readonly RetailCostBusinessRules _retailCostBusinessRules;

        public UpdateRetailCostCommandHandler(IMapper mapper, IRetailCostRepository retailCostRepository,
                                         RetailCostBusinessRules retailCostBusinessRules)
        {
            _mapper = mapper;
            _retailCostRepository = retailCostRepository;
            _retailCostBusinessRules = retailCostBusinessRules;
        }

        public async Task<UpdatedRetailCostResponse> Handle(UpdateRetailCostCommand request, CancellationToken cancellationToken)
        {
            RetailCost? retailCost = await _retailCostRepository.GetAsync(predicate: rc => rc.Id == request.Id, cancellationToken: cancellationToken);
            await _retailCostBusinessRules.RetailCostShouldExistWhenSelected(retailCost);
            retailCost = _mapper.Map(request, retailCost);

            await _retailCostRepository.UpdateAsync(retailCost!);

            UpdatedRetailCostResponse response = _mapper.Map<UpdatedRetailCostResponse>(retailCost);
            return response;
        }
    }
}