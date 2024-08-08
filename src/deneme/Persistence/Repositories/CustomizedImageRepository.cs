using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CustomizedImageRepository : EfRepositoryBase<CustomizedImage, Guid, BaseDbContext>, ICustomizedImageRepository
{
    public CustomizedImageRepository(BaseDbContext context) : base(context)
    {
    }
}