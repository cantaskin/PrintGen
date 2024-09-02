using Application.Features.Customizations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Customizations.Rules;

public class CustomizationBusinessRules : BaseBusinessRules
{
    private readonly ICustomizationRepository _customizationRepository;
    private readonly ILocalizationService _localizationService;

    public CustomizationBusinessRules(ICustomizationRepository customizationRepository, ILocalizationService localizationService)
    {
        _customizationRepository = customizationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CustomizationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CustomizationShouldExistWhenSelected(Customization? customization)
    {
        if (customization == null)
            await throwBusinessException(CustomizationsBusinessMessages.CustomizationNotExists);
    }

    public async Task CustomizationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Customization? customization = await _customizationRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomizationShouldExistWhenSelected(customization);
    }
}