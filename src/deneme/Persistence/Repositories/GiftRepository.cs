using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GiftRepository : EfRepositoryBase<Gift, Guid, BaseDbContext>, IGiftRepository
{
    public GiftRepository(BaseDbContext context) : base(context)
    {
    }
}