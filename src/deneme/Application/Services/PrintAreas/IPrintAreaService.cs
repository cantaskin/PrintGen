using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PrintAreas;

public interface IPrintAreaService
{
    Task<PrintArea?> GetAsync(
        Expression<Func<PrintArea, bool>> predicate,
        Func<IQueryable<PrintArea>, IIncludableQueryable<PrintArea, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<PrintArea>?> GetListAsync(
        Expression<Func<PrintArea, bool>>? predicate = null,
        Func<IQueryable<PrintArea>, IOrderedQueryable<PrintArea>>? orderBy = null,
        Func<IQueryable<PrintArea>, IIncludableQueryable<PrintArea, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<PrintArea> AddAsync(PrintArea printArea);
    Task<PrintArea> UpdateAsync(PrintArea printArea);
    Task<PrintArea> DeleteAsync(PrintArea printArea, bool permanent = false);
}
