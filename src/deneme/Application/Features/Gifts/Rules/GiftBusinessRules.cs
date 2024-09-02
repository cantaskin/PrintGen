using Application.Features.Gifts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Gifts.Rules;

public class GiftBusinessRules : BaseBusinessRules
{
    private readonly IGiftRepository _giftRepository;
    private readonly ILocalizationService _localizationService;

    public GiftBusinessRules(IGiftRepository giftRepository, ILocalizationService localizationService)
    {
        _giftRepository = giftRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, GiftsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task GiftShouldExistWhenSelected(Gift? gift)
    {
        if (gift == null)
            await throwBusinessException(GiftsBusinessMessages.GiftNotExists);
    }

    public async Task GiftIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Gift? gift = await _giftRepository.GetAsync(
            predicate: g => g.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GiftShouldExistWhenSelected(gift);
    }
}