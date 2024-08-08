using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPrintAreaRepository : IAsyncRepository<PrintArea, Guid>, IRepository<PrintArea, Guid>
{
}