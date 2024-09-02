using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrderItemRepository : EfRepositoryBase<OrderItem, Guid, BaseDbContext>, IOrderItemRepository
{
    public OrderItemRepository(BaseDbContext context) : base(context)
    {
    }
}