using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Gifts;

public interface IGiftService
{
    Task<Gift?> GetAsync(
        Expression<Func<Gift, bool>> predicate,
        Func<IQueryable<Gift>, IIncludableQueryable<Gift, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Gift>?> GetListAsync(
        Expression<Func<Gift, bool>>? predicate = null,
        Func<IQueryable<Gift>, IOrderedQueryable<Gift>>? orderBy = null,
        Func<IQueryable<Gift>, IIncludableQueryable<Gift, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Gift> AddAsync(Gift gift);
    Task<Gift> UpdateAsync(Gift gift);
    Task<Gift> DeleteAsync(Gift gift, bool permanent = false);
}
