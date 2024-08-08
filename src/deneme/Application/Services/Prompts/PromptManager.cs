using Application.Features.Prompts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Prompts;

public class PromptManager : IPromptService
{
    private readonly IPromptRepository _promptRepository;
    private readonly PromptBusinessRules _promptBusinessRules;

    public PromptManager(IPromptRepository promptRepository, PromptBusinessRules promptBusinessRules)
    {
        _promptRepository = promptRepository;
        _promptBusinessRules = promptBusinessRules;
    }

    public async Task<Prompt?> GetAsync(
        Expression<Func<Prompt, bool>> predicate,
        Func<IQueryable<Prompt>, IIncludableQueryable<Prompt, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Prompt? prompt = await _promptRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return prompt;
    }

    public async Task<IPaginate<Prompt>?> GetListAsync(
        Expression<Func<Prompt, bool>>? predicate = null,
        Func<IQueryable<Prompt>, IOrderedQueryable<Prompt>>? orderBy = null,
        Func<IQueryable<Prompt>, IIncludableQueryable<Prompt, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Prompt> promptList = await _promptRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return promptList;
    }

    public async Task<Prompt> AddAsync(Prompt prompt)
    {
        Prompt addedPrompt = await _promptRepository.AddAsync(prompt);

        return addedPrompt;
    }

    public async Task<Prompt> UpdateAsync(Prompt prompt)
    {
        Prompt updatedPrompt = await _promptRepository.UpdateAsync(prompt);

        return updatedPrompt;
    }

    public async Task<Prompt> DeleteAsync(Prompt prompt, bool permanent = false)
    {
        Prompt deletedPrompt = await _promptRepository.DeleteAsync(prompt);

        return deletedPrompt;
    }
}
