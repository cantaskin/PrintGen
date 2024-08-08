using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PrintAreaNames;

public interface IPrintAreaNameService
{
    Task<PrintAreaName?> GetAsync(
        Expression<Func<PrintAreaName, bool>> predicate,
        Func<IQueryable<PrintAreaName>, IIncludableQueryable<PrintAreaName, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PrintAreaName>?> GetListAsync(
        Expression<Func<PrintAreaName, bool>>? predicate = null,
        Func<IQueryable<PrintAreaName>, IOrderedQueryable<PrintAreaName>>? orderBy = null,
        Func<IQueryable<PrintAreaName>, IIncludableQueryable<PrintAreaName, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PrintAreaName> AddAsync(PrintAreaName printAreaName);
    Task<PrintAreaName> UpdateAsync(PrintAreaName printAreaName);
    Task<PrintAreaName> DeleteAsync(PrintAreaName printAreaName, bool permanent = false);
}
