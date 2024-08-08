using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductImageRepository : IAsyncRepository<ProductImage, Guid>, IRepository<ProductImage, Guid>
{
}