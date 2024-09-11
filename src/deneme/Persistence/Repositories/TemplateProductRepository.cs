using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TemplateProductRepository : EfRepositoryBase<TemplateProduct, Guid, BaseDbContext>, ITemplateProductRepository
{
    public TemplateProductRepository(BaseDbContext context) : base(context)
    {
    }
}