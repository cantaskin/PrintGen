using Application.Features.Placements.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Placements.Rules;

public class PlacementBusinessRules : BaseBusinessRules
{
    private readonly IPlacementRepository _placementRepository;
    private readonly ILocalizationService _localizationService;

    public PlacementBusinessRules(IPlacementRepository placementRepository, ILocalizationService localizationService)
    {
        _placementRepository = placementRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PlacementsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PlacementShouldExistWhenSelected(Placement? placement)
    {
        if (placement == null)
            await throwBusinessException(PlacementsBusinessMessages.PlacementNotExists);
    }

    public async Task PlacementIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Placement? placement = await _placementRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PlacementShouldExistWhenSelected(placement);
    }
}