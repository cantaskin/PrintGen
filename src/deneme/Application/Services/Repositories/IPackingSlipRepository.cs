using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPackingSlipRepository : IAsyncRepository<PackingSlip, Guid>, IRepository<PackingSlip, Guid>
{
}