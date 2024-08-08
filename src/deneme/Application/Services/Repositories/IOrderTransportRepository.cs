using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOrderTransportRepository : IAsyncRepository<OrderTransport, Guid>, IRepository<OrderTransport, Guid>
{
}