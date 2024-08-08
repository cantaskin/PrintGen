using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICustomizedImageRepository : IAsyncRepository<CustomizedImage, Guid>, IRepository<CustomizedImage, Guid>
{
}