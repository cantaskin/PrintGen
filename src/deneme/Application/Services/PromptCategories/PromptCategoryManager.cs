using Application.Features.PromptCategories.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PromptCategories;

public class PromptCategoryManager : IPromptCategoryService
{
    private readonly IPromptCategoryRepository _promptCategoryRepository;
    private readonly PromptCategoryBusinessRules _promptCategoryBusinessRules;

    public PromptCategoryManager(IPromptCategoryRepository promptCategoryRepository, PromptCategoryBusinessRules promptCategoryBusinessRules)
    {
        _promptCategoryRepository = promptCategoryRepository;
        _promptCategoryBusinessRules = promptCategoryBusinessRules;
    }

    public async Task<PromptCategory?> GetAsync(
        Expression<Func<PromptCategory, bool>> predicate,
        Func<IQueryable<PromptCategory>, IIncludableQueryable<PromptCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PromptCategory? promptCategory = await _promptCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return promptCategory;
    }

    public async Task<IPaginate<PromptCategory>?> GetListAsync(
        Expression<Func<PromptCategory, bool>>? predicate = null,
        Func<IQueryable<PromptCategory>, IOrderedQueryable<PromptCategory>>? orderBy = null,
        Func<IQueryable<PromptCategory>, IIncludableQueryable<PromptCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PromptCategory> promptCategoryList = await _promptCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return promptCategoryList;
    }

    public async Task<PromptCategory> AddAsync(PromptCategory promptCategory)
    {
        PromptCategory addedPromptCategory = await _promptCategoryRepository.AddAsync(promptCategory);

        return addedPromptCategory;
    }

    public async Task<PromptCategory> UpdateAsync(PromptCategory promptCategory)
    {
        PromptCategory updatedPromptCategory = await _promptCategoryRepository.UpdateAsync(promptCategory);

        return updatedPromptCategory;
    }

    public async Task<PromptCategory> DeleteAsync(PromptCategory promptCategory, bool permanent = false)
    {
        PromptCategory deletedPromptCategory = await _promptCategoryRepository.DeleteAsync(promptCategory);

        return deletedPromptCategory;
    }
}
