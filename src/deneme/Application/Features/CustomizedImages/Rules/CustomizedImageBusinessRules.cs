using Application.Features.CustomizedImages.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CustomizedImages.Rules;

public class CustomizedImageBusinessRules : BaseBusinessRules
{
    private readonly ICustomizedImageRepository _customizedImageRepository;
    private readonly ILocalizationService _localizationService;

    public CustomizedImageBusinessRules(ICustomizedImageRepository customizedImageRepository, ILocalizationService localizationService)
    {
        _customizedImageRepository = customizedImageRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CustomizedImagesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CustomizedImageShouldExistWhenSelected(CustomizedImage? customizedImage)
    {
        if (customizedImage == null)
            await throwBusinessException(CustomizedImagesBusinessMessages.CustomizedImageNotExists);
    }

    public async Task CustomizedImageIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CustomizedImage? customizedImage = await _customizedImageRepository.GetAsync(
            predicate: ci => ci.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomizedImageShouldExistWhenSelected(customizedImage);
    }
}