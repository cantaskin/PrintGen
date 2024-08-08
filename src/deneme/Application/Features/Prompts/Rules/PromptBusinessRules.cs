using Application.Features.Prompts.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Prompts.Rules;

public class PromptBusinessRules : BaseBusinessRules
{
    private readonly IPromptRepository _promptRepository;
    private readonly ILocalizationService _localizationService;

    public PromptBusinessRules(IPromptRepository promptRepository, ILocalizationService localizationService)
    {
        _promptRepository = promptRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, PromptsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task PromptShouldExistWhenSelected(Prompt? prompt)
    {
        if (prompt == null)
            await throwBusinessException(PromptsBusinessMessages.PromptNotExists);
    }

    public async Task PromptIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Prompt? prompt = await _promptRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await PromptShouldExistWhenSelected(prompt);
    }
}