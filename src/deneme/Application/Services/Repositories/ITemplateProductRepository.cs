using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITemplateProductRepository : IAsyncRepository<TemplateProduct, Guid>, IRepository<TemplateProduct, Guid>
{
}