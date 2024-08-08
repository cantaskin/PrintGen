using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomizedProducts;

public interface ICustomizedProductService
{
    Task<CustomizedProduct?> GetAsync(
        Expression<Func<CustomizedProduct, bool>> predicate,
        Func<IQueryable<CustomizedProduct>, IIncludableQueryable<CustomizedProduct, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomizedProduct>?> GetListAsync(
        Expression<Func<CustomizedProduct, bool>>? predicate = null,
        Func<IQueryable<CustomizedProduct>, IOrderedQueryable<CustomizedProduct>>? orderBy = null,
        Func<IQueryable<CustomizedProduct>, IIncludableQueryable<CustomizedProduct, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomizedProduct> AddAsync(CustomizedProduct customizedProduct);
    Task<CustomizedProduct> UpdateAsync(CustomizedProduct customizedProduct);
    Task<CustomizedProduct> DeleteAsync(CustomizedProduct customizedProduct, bool permanent = false);
}
