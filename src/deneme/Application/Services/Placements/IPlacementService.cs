using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Placements;

public interface IPlacementService
{
    Task<Placement?> GetAsync(
        Expression<Func<Placement, bool>> predicate,
        Func<IQueryable<Placement>, IIncludableQueryable<Placement, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Placement>?> GetListAsync(
        Expression<Func<Placement, bool>>? predicate = null,
        Func<IQueryable<Placement>, IOrderedQueryable<Placement>>? orderBy = null,
        Func<IQueryable<Placement>, IIncludableQueryable<Placement, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Placement> AddAsync(Placement placement);
    Task<Placement> UpdateAsync(Placement placement);
    Task<Placement> DeleteAsync(Placement placement, bool permanent = false);
}
