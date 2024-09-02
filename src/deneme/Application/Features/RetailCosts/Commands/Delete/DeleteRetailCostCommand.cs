using Application.Features.RetailCosts.Constants;
using Application.Features.RetailCosts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.RetailCosts.Commands.Delete;

public class DeleteRetailCostCommand : IRequest<DeletedRetailCostResponse>
{
    public Guid Id { get; set; }

    public class DeleteRetailCostCommandHandler : IRequestHandler<DeleteRetailCostCommand, DeletedRetailCostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRetailCostRepository _retailCostRepository;
        private readonly RetailCostBusinessRules _retailCostBusinessRules;

        public DeleteRetailCostCommandHandler(IMapper mapper, IRetailCostRepository retailCostRepository,
                                         RetailCostBusinessRules retailCostBusinessRules)
        {
            _mapper = mapper;
            _retailCostRepository = retailCostRepository;
            _retailCostBusinessRules = retailCostBusinessRules;
        }

        public async Task<DeletedRetailCostResponse> Handle(DeleteRetailCostCommand request, CancellationToken cancellationToken)
        {
            RetailCost? retailCost = await _retailCostRepository.GetAsync(predicate: rc => rc.Id == request.Id, cancellationToken: cancellationToken);
            await _retailCostBusinessRules.RetailCostShouldExistWhenSelected(retailCost);

            await _retailCostRepository.DeleteAsync(retailCost!);

            DeletedRetailCostResponse response = _mapper.Map<DeletedRetailCostResponse>(retailCost);
            return response;
        }
    }
}