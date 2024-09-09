using Application.Features.Options.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Options.Rules;

public class OptionBusinessRules : BaseBusinessRules
{
    private readonly IOptionRepository _optionRepository;
    private readonly ILocalizationService _localizationService;

    public OptionBusinessRules(IOptionRepository optionRepository, ILocalizationService localizationService)
    {
        _optionRepository = optionRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, OptionsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task OptionShouldExistWhenSelected(Option? option)
    {
        if (option == null)
            await throwBusinessException(OptionsBusinessMessages.OptionNotExists);
    }

    public async Task OptionIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Option? option = await _optionRepository.GetAsync(
            predicate: o => o.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await OptionShouldExistWhenSelected(option);
    }
}