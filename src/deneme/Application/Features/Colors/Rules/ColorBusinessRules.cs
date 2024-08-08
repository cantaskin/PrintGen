using Application.Features.Colors.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Colors.Rules;

public class ColorBusinessRules : BaseBusinessRules
{
    private readonly IColorRepository _colorRepository;
    private readonly ILocalizationService _localizationService;

    public ColorBusinessRules(IColorRepository colorRepository, ILocalizationService localizationService)
    {
        _colorRepository = colorRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ColorsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ColorShouldExistWhenSelected(Color? color)
    {
        if (color == null)
            await throwBusinessException(ColorsBusinessMessages.ColorNotExists);
    }

    public async Task ColorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Color? color = await _colorRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ColorShouldExistWhenSelected(color);
    }
}