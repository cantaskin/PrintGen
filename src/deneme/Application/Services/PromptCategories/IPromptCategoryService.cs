using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PromptCategories;

public interface IPromptCategoryService
{
    Task<PromptCategory?> GetAsync(
        Expression<Func<PromptCategory, bool>> predicate,
        Func<IQueryable<PromptCategory>, IIncludableQueryable<PromptCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PromptCategory>?> GetListAsync(
        Expression<Func<PromptCategory, bool>>? predicate = null,
        Func<IQueryable<PromptCategory>, IOrderedQueryable<PromptCategory>>? orderBy = null,
        Func<IQueryable<PromptCategory>, IIncludableQueryable<PromptCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PromptCategory> AddAsync(PromptCategory promptCategory);
    Task<PromptCategory> UpdateAsync(PromptCategory promptCategory);
    Task<PromptCategory> DeleteAsync(PromptCategory promptCategory, bool permanent = false);
}
