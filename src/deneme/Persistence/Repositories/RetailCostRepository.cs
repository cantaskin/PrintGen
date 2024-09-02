using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RetailCostRepository : EfRepositoryBase<RetailCost, Guid, BaseDbContext>, IRetailCostRepository
{
    public RetailCostRepository(BaseDbContext context) : base(context)
    {
    }
}