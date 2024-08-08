using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomizedProductRepository : EfRepositoryBase<CustomizedProduct, Guid, BaseDbContext>, ICustomizedProductRepository
{
    public CustomizedProductRepository(BaseDbContext context) : base(context)
    {
    }
}