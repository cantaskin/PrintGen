using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OptionRepository : EfRepositoryBase<Option, Guid, BaseDbContext>, IOptionRepository
{
    public OptionRepository(BaseDbContext context) : base(context)
    {
    }
}