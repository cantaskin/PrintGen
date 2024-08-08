using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ColorRepository : EfRepositoryBase<Color, Guid, BaseDbContext>, IColorRepository
{
    public ColorRepository(BaseDbContext context) : base(context)
    {
    }
}