using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Positions;

public interface IPositionService
{
    Task<Position?> GetAsync(
        Expression<Func<Position, bool>> predicate,
        Func<IQueryable<Position>, IIncludableQueryable<Position, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Position>?> GetListAsync(
        Expression<Func<Position, bool>>? predicate = null,
        Func<IQueryable<Position>, IOrderedQueryable<Position>>? orderBy = null,
        Func<IQueryable<Position>, IIncludableQueryable<Position, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Position> AddAsync(Position position);
    Task<Position> UpdateAsync(Position position);
    Task<Position> DeleteAsync(Position position, bool permanent = false);
}
