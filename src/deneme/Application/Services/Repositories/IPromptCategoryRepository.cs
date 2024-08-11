using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPromptCategoryRepository : IAsyncRepository<PromptCategory, Guid>, IRepository<PromptCategory, Guid>
{
}