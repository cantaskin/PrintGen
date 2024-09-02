using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PackingSlipRepository : EfRepositoryBase<PackingSlip, Guid, BaseDbContext>, IPackingSlipRepository
{
    public PackingSlipRepository(BaseDbContext context) : base(context)
    {
    }
}