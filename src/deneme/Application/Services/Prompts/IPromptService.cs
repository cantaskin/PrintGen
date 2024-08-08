using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Prompts;

public interface IPromptService
{
    Task<Prompt?> GetAsync(
        Expression<Func<Prompt, bool>> predicate,
        Func<IQueryable<Prompt>, IIncludableQueryable<Prompt, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Prompt>?> GetListAsync(
        Expression<Func<Prompt, bool>>? predicate = null,
        Func<IQueryable<Prompt>, IOrderedQueryable<Prompt>>? orderBy = null,
        Func<IQueryable<Prompt>, IIncludableQueryable<Prompt, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Prompt> AddAsync(Prompt prompt);
    Task<Prompt> UpdateAsync(Prompt prompt);
    Task<Prompt> DeleteAsync(Prompt prompt, bool permanent = false);
}
