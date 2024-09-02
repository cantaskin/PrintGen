using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILayerRepository : IAsyncRepository<Layer, Guid>, IRepository<Layer, Guid>
{
}