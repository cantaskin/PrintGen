using Application.Features.PackingSlips.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PackingSlips.Rules;

public class PackingSlipBusinessRules : BaseBusinessRules
{
    private readonly IPackingSlipRepository _packingSlipRepository;
    private readonly ILocalizationService _localizationService;

    public PackingSlipBusinessRules(IPackingSlipRepository packingSlipRepository, ILocalizationService localizationService)
    {
        _packingSlipRepository = packingSlipRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PackingSlipsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PackingSlipShouldExistWhenSelected(PackingSlip? packingSlip)
    {
        if (packingSlip == null)
            await throwBusinessException(PackingSlipsBusinessMessages.PackingSlipNotExists);
    }

    public async Task PackingSlipIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        PackingSlip? packingSlip = await _packingSlipRepository.GetAsync(
            predicate: ps => ps.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PackingSlipShouldExistWhenSelected(packingSlip);
    }
}