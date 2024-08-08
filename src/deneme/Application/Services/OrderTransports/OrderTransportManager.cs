using Application.Features.OrderTransports.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrderTransports;

public class OrderTransportManager : IOrderTransportService
{
    private readonly IOrderTransportRepository _orderTransportRepository;
    private readonly OrderTransportBusinessRules _orderTransportBusinessRules;

    public OrderTransportManager(IOrderTransportRepository orderTransportRepository, OrderTransportBusinessRules orderTransportBusinessRules)
    {
        _orderTransportRepository = orderTransportRepository;
        _orderTransportBusinessRules = orderTransportBusinessRules;
    }

    public async Task<OrderTransport?> GetAsync(
        Expression<Func<OrderTransport, bool>> predicate,
        Func<IQueryable<OrderTransport>, IIncludableQueryable<OrderTransport, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        OrderTransport? orderTransport = await _orderTransportRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return orderTransport;
    }

    public async Task<IPaginate<OrderTransport>?> GetListAsync(
        Expression<Func<OrderTransport, bool>>? predicate = null,
        Func<IQueryable<OrderTransport>, IOrderedQueryable<OrderTransport>>? orderBy = null,
        Func<IQueryable<OrderTransport>, IIncludableQueryable<OrderTransport, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<OrderTransport> orderTransportList = await _orderTransportRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return orderTransportList;
    }

    public async Task<OrderTransport> AddAsync(OrderTransport orderTransport)
    {
        OrderTransport addedOrderTransport = await _orderTransportRepository.AddAsync(orderTransport);

        return addedOrderTransport;
    }

    public async Task<OrderTransport> UpdateAsync(OrderTransport orderTransport)
    {
        OrderTransport updatedOrderTransport = await _orderTransportRepository.UpdateAsync(orderTransport);

        return updatedOrderTransport;
    }

    public async Task<OrderTransport> DeleteAsync(OrderTransport orderTransport, bool permanent = false)
    {
        OrderTransport deletedOrderTransport = await _orderTransportRepository.DeleteAsync(orderTransport);

        return deletedOrderTransport;
    }
}
