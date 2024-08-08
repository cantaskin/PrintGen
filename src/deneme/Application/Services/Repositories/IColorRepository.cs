using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IColorRepository : IAsyncRepository<Color, Guid>, IRepository<Color, Guid>
{
}