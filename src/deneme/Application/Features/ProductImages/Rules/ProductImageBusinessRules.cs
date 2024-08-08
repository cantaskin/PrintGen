using Application.Features.ProductImages.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ProductImages.Rules;

public class ProductImageBusinessRules : BaseBusinessRules
{
    private readonly IProductImageRepository _productImageRepository;
    private readonly ILocalizationService _localizationService;

    public ProductImageBusinessRules(IProductImageRepository productImageRepository, ILocalizationService localizationService)
    {
        _productImageRepository = productImageRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ProductImagesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ProductImageShouldExistWhenSelected(ProductImage? productImage)
    {
        if (productImage == null)
            await throwBusinessException(ProductImagesBusinessMessages.ProductImageNotExists);
    }

    public async Task ProductImageIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ProductImage? productImage = await _productImageRepository.GetAsync(
            predicate: pi => pi.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductImageShouldExistWhenSelected(productImage);
    }
}