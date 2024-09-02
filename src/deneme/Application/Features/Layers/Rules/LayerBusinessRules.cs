using Application.Features.Layers.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Layers.Rules;

public class LayerBusinessRules : BaseBusinessRules
{
    private readonly ILayerRepository _layerRepository;
    private readonly ILocalizationService _localizationService;

    public LayerBusinessRules(ILayerRepository layerRepository, ILocalizationService localizationService)
    {
        _layerRepository = layerRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, LayersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task LayerShouldExistWhenSelected(Layer? layer)
    {
        if (layer == null)
            await throwBusinessException(LayersBusinessMessages.LayerNotExists);
    }

    public async Task LayerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Layer? layer = await _layerRepository.GetAsync(
            predicate: l => l.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await LayerShouldExistWhenSelected(layer);
    }
}