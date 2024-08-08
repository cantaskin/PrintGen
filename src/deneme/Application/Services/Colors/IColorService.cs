using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Colors;

public interface IColorService
{
    Task<Color?> GetAsync(
        Expression<Func<Color, bool>> predicate,
        Func<IQueryable<Color>, IIncludableQueryable<Color, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Color>?> GetListAsync(
        Expression<Func<Color, bool>>? predicate = null,
        Func<IQueryable<Color>, IOrderedQueryable<Color>>? orderBy = null,
        Func<IQueryable<Color>, IIncludableQueryable<Color, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Color> AddAsync(Color color);
    Task<Color> UpdateAsync(Color color);
    Task<Color> DeleteAsync(Color color, bool permanent = false);
}
