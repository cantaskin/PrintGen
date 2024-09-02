using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PlacementRepository : EfRepositoryBase<Placement, Guid, BaseDbContext>, IPlacementRepository
{
    public PlacementRepository(BaseDbContext context) : base(context)
    {
    }
}