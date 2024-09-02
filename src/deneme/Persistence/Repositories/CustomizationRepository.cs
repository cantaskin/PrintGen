using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomizationRepository : EfRepositoryBase<Customization, Guid, BaseDbContext>, ICustomizationRepository
{
    public CustomizationRepository(BaseDbContext context) : base(context)
    {
    }
}