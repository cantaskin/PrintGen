using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRetailCostRepository : IAsyncRepository<RetailCost, Guid>, IRepository<RetailCost, Guid>
{
}