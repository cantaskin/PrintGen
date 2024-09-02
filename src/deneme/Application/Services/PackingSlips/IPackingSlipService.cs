using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PackingSlips;

public interface IPackingSlipService
{
    Task<PackingSlip?> GetAsync(
        Expression<Func<PackingSlip, bool>> predicate,
        Func<IQueryable<PackingSlip>, IIncludableQueryable<PackingSlip, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PackingSlip>?> GetListAsync(
        Expression<Func<PackingSlip, bool>>? predicate = null,
        Func<IQueryable<PackingSlip>, IOrderedQueryable<PackingSlip>>? orderBy = null,
        Func<IQueryable<PackingSlip>, IIncludableQueryable<PackingSlip, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PackingSlip> AddAsync(PackingSlip packingSlip);
    Task<PackingSlip> UpdateAsync(PackingSlip packingSlip);
    Task<PackingSlip> DeleteAsync(PackingSlip packingSlip, bool permanent = false);
}
