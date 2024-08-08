using Application.Features.CustomizedProducts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.CustomizedProducts.Rules;

public class CustomizedProductBusinessRules : BaseBusinessRules
{
    private readonly ICustomizedProductRepository _customizedProductRepository;
    private readonly ILocalizationService _localizationService;

    public CustomizedProductBusinessRules(ICustomizedProductRepository customizedProductRepository, ILocalizationService localizationService)
    {
        _customizedProductRepository = customizedProductRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CustomizedProductsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CustomizedProductShouldExistWhenSelected(CustomizedProduct? customizedProduct)
    {
        if (customizedProduct == null)
            await throwBusinessException(CustomizedProductsBusinessMessages.CustomizedProductNotExists);
    }

    public async Task CustomizedProductIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        CustomizedProduct? customizedProduct = await _customizedProductRepository.GetAsync(
            predicate: cp => cp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomizedProductShouldExistWhenSelected(customizedProduct);
    }
}