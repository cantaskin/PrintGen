using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomizedProductRepository : IAsyncRepository<CustomizedProduct, Guid>, IRepository<CustomizedProduct, Guid>
{
}