using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomizationRepository : IAsyncRepository<Customization, Guid>, IRepository<Customization, Guid>
{
}