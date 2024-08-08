using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PrintAreaRepository : EfRepositoryBase<PrintArea, Guid, BaseDbContext>, IPrintAreaRepository
{
    public PrintAreaRepository(BaseDbContext context) : base(context)
    {
    }
}