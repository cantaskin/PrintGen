using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPlacementRepository : IAsyncRepository<Placement, Guid>, IRepository<Placement, Guid>
{
}