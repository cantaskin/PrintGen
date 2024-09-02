using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrderItems;

public interface IOrderItemService
{
    Task<OrderItem?> GetAsync(
        Expression<Func<OrderItem, bool>> predicate,
        Func<IQueryable<OrderItem>, IIncludableQueryable<OrderItem, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<OrderItem>?> GetListAsync(
        Expression<Func<OrderItem, bool>>? predicate = null,
        Func<IQueryable<OrderItem>, IOrderedQueryable<OrderItem>>? orderBy = null,
        Func<IQueryable<OrderItem>, IIncludableQueryable<OrderItem, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<OrderItem> AddAsync(OrderItem orderItem);
    Task<OrderItem> UpdateAsync(OrderItem orderItem);
    Task<OrderItem> DeleteAsync(OrderItem orderItem, bool permanent = false);
}
