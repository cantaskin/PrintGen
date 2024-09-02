using Application.Features.OrderItems.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrderItems;

public class OrderItemManager : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly OrderItemBusinessRules _orderItemBusinessRules;

    public OrderItemManager(IOrderItemRepository orderItemRepository, OrderItemBusinessRules orderItemBusinessRules)
    {
        _orderItemRepository = orderItemRepository;
        _orderItemBusinessRules = orderItemBusinessRules;
    }

    public async Task<OrderItem?> GetAsync(
        Expression<Func<OrderItem, bool>> predicate,
        Func<IQueryable<OrderItem>, IIncludableQueryable<OrderItem, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        OrderItem? orderItem = await _orderItemRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return orderItem;
    }

    public async Task<IPaginate<OrderItem>?> GetListAsync(
        Expression<Func<OrderItem, bool>>? predicate = null,
        Func<IQueryable<OrderItem>, IOrderedQueryable<OrderItem>>? orderBy = null,
        Func<IQueryable<OrderItem>, IIncludableQueryable<OrderItem, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<OrderItem> orderItemList = await _orderItemRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return orderItemList;
    }

    public async Task<OrderItem> AddAsync(OrderItem orderItem)
    {
        OrderItem addedOrderItem = await _orderItemRepository.AddAsync(orderItem);

        return addedOrderItem;
    }

    public async Task<OrderItem> UpdateAsync(OrderItem orderItem)
    {
        OrderItem updatedOrderItem = await _orderItemRepository.UpdateAsync(orderItem);

        return updatedOrderItem;
    }

    public async Task<OrderItem> DeleteAsync(OrderItem orderItem, bool permanent = false)
    {
        OrderItem deletedOrderItem = await _orderItemRepository.DeleteAsync(orderItem);

        return deletedOrderItem;
    }
}
