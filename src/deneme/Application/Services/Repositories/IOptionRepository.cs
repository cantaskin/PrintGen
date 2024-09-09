using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IOptionRepository : IAsyncRepository<Option, Guid>, IRepository<Option, Guid>
{
}