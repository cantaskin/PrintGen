using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OrderTransportRepository : EfRepositoryBase<OrderTransport, Guid, BaseDbContext>, IOrderTransportRepository
{
    public OrderTransportRepository(BaseDbContext context) : base(context)
    {
    }
}