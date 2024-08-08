using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IPromptRepository : IAsyncRepository<Prompt, Guid>, IRepository<Prompt, Guid>
{
}