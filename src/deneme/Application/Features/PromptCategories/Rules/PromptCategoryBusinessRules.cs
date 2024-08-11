using Application.Features.PromptCategories.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.PromptCategories.Rules;

public class PromptCategoryBusinessRules : BaseBusinessRules
{
    private readonly IPromptCategoryRepository _promptCategoryRepository;
    private readonly ILocalizationService _localizationService;

    public PromptCategoryBusinessRules(IPromptCategoryRepository promptCategoryRepository, ILocalizationService localizationService)
    {
        _promptCategoryRepository = promptCategoryRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PromptCategoriesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PromptCategoryShouldExistWhenSelected(PromptCategory? promptCategory)
    {
        if (promptCategory == null)
            await throwBusinessException(PromptCategoriesBusinessMessages.PromptCategoryNotExists);
    }

    public async Task PromptCategoryIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        PromptCategory? promptCategory = await _promptCategoryRepository.GetAsync(
            predicate: pc => pc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PromptCategoryShouldExistWhenSelected(promptCategory);
    }
}