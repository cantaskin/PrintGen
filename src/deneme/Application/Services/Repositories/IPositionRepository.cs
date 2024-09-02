using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPositionRepository : IAsyncRepository<Position, Guid>, IRepository<Position, Guid>
{
}