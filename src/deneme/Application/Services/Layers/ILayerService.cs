using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Layers;

public interface ILayerService
{
    Task<Layer?> GetAsync(
        Expression<Func<Layer, bool>> predicate,
        Func<IQueryable<Layer>, IIncludableQueryable<Layer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Layer>?> GetListAsync(
        Expression<Func<Layer, bool>>? predicate = null,
        Func<IQueryable<Layer>, IOrderedQueryable<Layer>>? orderBy = null,
        Func<IQueryable<Layer>, IIncludableQueryable<Layer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Layer> AddAsync(Layer layer);
    Task<Layer> UpdateAsync(Layer layer);
    Task<Layer> DeleteAsync(Layer layer, bool permanent = false);
}
