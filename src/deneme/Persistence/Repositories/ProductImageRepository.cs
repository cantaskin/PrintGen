using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductImageRepository : EfRepositoryBase<ProductImage, Guid, BaseDbContext>, IProductImageRepository
{
    public ProductImageRepository(BaseDbContext context) : base(context)
    {
    }
}