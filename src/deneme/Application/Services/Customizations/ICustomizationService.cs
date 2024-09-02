using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Customizations;

public interface ICustomizationService
{
    Task<Customization?> GetAsync(
        Expression<Func<Customization, bool>> predicate,
        Func<IQueryable<Customization>, IIncludableQueryable<Customization, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Customization>?> GetListAsync(
        Expression<Func<Customization, bool>>? predicate = null,
        Func<IQueryable<Customization>, IOrderedQueryable<Customization>>? orderBy = null,
        Func<IQueryable<Customization>, IIncludableQueryable<Customization, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Customization> AddAsync(Customization customization);
    Task<Customization> UpdateAsync(Customization customization);
    Task<Customization> DeleteAsync(Customization customization, bool permanent = false);
}
