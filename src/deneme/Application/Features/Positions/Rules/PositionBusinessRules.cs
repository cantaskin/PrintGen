using Application.Features.Positions.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Positions.Rules;

public class PositionBusinessRules : BaseBusinessRules
{
    private readonly IPositionRepository _positionRepository;
    private readonly ILocalizationService _localizationService;

    public PositionBusinessRules(IPositionRepository positionRepository, ILocalizationService localizationService)
    {
        _positionRepository = positionRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PositionsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PositionShouldExistWhenSelected(Position? position)
    {
        if (position == null)
            await throwBusinessException(PositionsBusinessMessages.PositionNotExists);
    }

    public async Task PositionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Position? position = await _positionRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PositionShouldExistWhenSelected(position);
    }
}