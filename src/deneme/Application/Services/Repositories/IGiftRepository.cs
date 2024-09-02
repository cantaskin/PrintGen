using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IGiftRepository : IAsyncRepository<Gift, Guid>, IRepository<Gift, Guid>
{
}