using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PrintAreaNameRepository : EfRepositoryBase<PrintAreaName, Guid, BaseDbContext>, IPrintAreaNameRepository
{
    public PrintAreaNameRepository(BaseDbContext context) : base(context)
    {
    }
}