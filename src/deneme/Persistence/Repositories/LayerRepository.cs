using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LayerRepository : EfRepositoryBase<Layer, Guid, BaseDbContext>, ILayerRepository
{
    public LayerRepository(BaseDbContext context) : base(context)
    {
    }
}