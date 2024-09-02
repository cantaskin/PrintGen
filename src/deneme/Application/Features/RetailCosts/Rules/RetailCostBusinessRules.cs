using Application.Features.RetailCosts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.RetailCosts.Rules;

public class RetailCostBusinessRules : BaseBusinessRules
{
    private readonly IRetailCostRepository _retailCostRepository;
    private readonly ILocalizationService _localizationService;

    public RetailCostBusinessRules(IRetailCostRepository retailCostRepository, ILocalizationService localizationService)
    {
        _retailCostRepository = retailCostRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, RetailCostsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task RetailCostShouldExistWhenSelected(RetailCost? retailCost)
    {
        if (retailCost == null)
            await throwBusinessException(RetailCostsBusinessMessages.RetailCostNotExists);
    }

    public async Task RetailCostIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        RetailCost? retailCost = await _retailCostRepository.GetAsync(
            predicate: rc => rc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await RetailCostShouldExistWhenSelected(retailCost);
    }
}