using Application.Features.Orders.Commands.Create;
using Application.Features.Orders.Rules;
using Application.Services.Addresses;
using Application.Services.OrderItems;
using Application.Services.Repositories;
using Application.Services.RetailCosts;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Orders;

public class OrderManager : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly OrderBusinessRules _orderBusinessRules;
    private readonly IOrderItemService _orderItemService;
    private readonly IAddressService _addressService;
    private readonly IRetailCostService _retailCostService;

    public OrderManager(IOrderRepository orderRepository, OrderBusinessRules orderBusinessRules, IAddressService addressService, IOrderItemService orderItemService, IRetailCostService retailCostService)
    {
        _orderRepository = orderRepository;
        _orderBusinessRules = orderBusinessRules;
        _addressService = addressService;
        _orderItemService = orderItemService;
        _retailCostService = retailCostService;
    }

    public async Task<Order?> GetAsync(
        Expression<Func<Order, bool>> predicate,
        Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Order? order = await _orderRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return order;
    }

    public async Task<IPaginate<Order>?> GetListAsync(
        Expression<Func<Order, bool>>? predicate = null,
        Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null,
        Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Order> orderList = await _orderRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return orderList;
    }

    public async Task<Order> AddAsync(Order order)
    {
        Order addedOrder = await _orderRepository.AddAsync(order);

        return addedOrder;
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        Order updatedOrder = await _orderRepository.UpdateAsync(order);

        return updatedOrder;
    }

    public async Task<Order> DeleteAsync(Order order, bool permanent = false)
    {
        Order deletedOrder = await _orderRepository.DeleteAsync(order);

        return deletedOrder;
    }

    public async Task<Address> GetOrderAddressAsync(Order order)
    {
        Address? address = await _addressService.GetAsync(a => a.Id == order.AddressId);

        if (address == null)
        {
            throw new Exception("Address not found");
        }

        return address;
    }

    public  async Task<List<OrderItem>> GetOrderOrderItemsAsync(Guid orderId)
    {
        var orderItems = await _orderItemService.GetListAsync(
            oi => oi.OrderId == orderId,
            index: 0,
            size: int.MaxValue
        );

        return orderItems.Items.ToList();
    }

    public async Task<RetailCost> GetRetailCostAsync(Order order)
    {
       return await _retailCostService.GetAsync(o => o.OrderId == order.Id);
    }
}
