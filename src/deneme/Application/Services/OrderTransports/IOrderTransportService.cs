using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrderTransports;

public interface IOrderTransportService
{
    Task<OrderTransport?> GetAsync(
        Expression<Func<OrderTransport, bool>> predicate,
        Func<IQueryable<OrderTransport>, IIncludableQueryable<OrderTransport, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<OrderTransport>?> GetListAsync(
        Expression<Func<OrderTransport, bool>>? predicate = null,
        Func<IQueryable<OrderTransport>, IOrderedQueryable<OrderTransport>>? orderBy = null,
        Func<IQueryable<OrderTransport>, IIncludableQueryable<OrderTransport, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<OrderTransport> AddAsync(OrderTransport orderTransport);
    Task<OrderTransport> UpdateAsync(OrderTransport orderTransport);
    Task<OrderTransport> DeleteAsync(OrderTransport orderTransport, bool permanent = false);
}
