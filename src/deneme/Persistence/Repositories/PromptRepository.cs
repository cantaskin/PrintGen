using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class PromptRepository : EfRepositoryBase<Prompt, Guid, BaseDbContext>, IPromptRepository
{
    public PromptRepository(BaseDbContext context) : base(context)
    {
    }
}