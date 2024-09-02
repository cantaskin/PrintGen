using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RetailCosts;

public interface IRetailCostService
{
    Task<RetailCost?> GetAsync(
        Expression<Func<RetailCost, bool>> predicate,
        Func<IQueryable<RetailCost>, IIncludableQueryable<RetailCost, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<RetailCost>?> GetListAsync(
        Expression<Func<RetailCost, bool>>? predicate = null,
        Func<IQueryable<RetailCost>, IOrderedQueryable<RetailCost>>? orderBy = null,
        Func<IQueryable<RetailCost>, IIncludableQueryable<RetailCost, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<RetailCost> AddAsync(RetailCost retailCost);
    Task<RetailCost> UpdateAsync(RetailCost retailCost);
    Task<RetailCost> DeleteAsync(RetailCost retailCost, bool permanent = false);
}
