using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPrintAreaNameRepository : IAsyncRepository<PrintAreaName, Guid>, IRepository<PrintAreaName, Guid>
{
}