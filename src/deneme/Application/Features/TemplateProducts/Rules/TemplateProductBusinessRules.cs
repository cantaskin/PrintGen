using Application.Features.TemplateProducts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.TemplateProducts.Rules;

public class TemplateProductBusinessRules : BaseBusinessRules
{
    private readonly ITemplateProductRepository _templateProductRepository;
    private readonly ILocalizationService _localizationService;

    public TemplateProductBusinessRules(ITemplateProductRepository templateProductRepository, ILocalizationService localizationService)
    {
        _templateProductRepository = templateProductRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, TemplateProductsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task TemplateProductShouldExistWhenSelected(TemplateProduct? templateProduct)
    {
        if (templateProduct == null)
            await throwBusinessException(TemplateProductsBusinessMessages.TemplateProductNotExists);
    }

    public async Task TemplateProductIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        TemplateProduct? templateProduct = await _templateProductRepository.GetAsync(
            predicate: tp => tp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TemplateProductShouldExistWhenSelected(templateProduct);
    }
}