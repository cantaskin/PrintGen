using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PromptCategoryRepository : EfRepositoryBase<PromptCategory, Guid, BaseDbContext>, IPromptCategoryRepository
{
    public PromptCategoryRepository(BaseDbContext context) : base(context)
    {
    }
}