using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TemplateProducts;

public interface ITemplateProductService
{
    Task<TemplateProduct?> GetAsync(
        Expression<Func<TemplateProduct, bool>> predicate,
        Func<IQueryable<TemplateProduct>, IIncludableQueryable<TemplateProduct, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TemplateProduct>?> GetListAsync(
        Expression<Func<TemplateProduct, bool>>? predicate = null,
        Func<IQueryable<TemplateProduct>, IOrderedQueryable<TemplateProduct>>? orderBy = null,
        Func<IQueryable<TemplateProduct>, IIncludableQueryable<TemplateProduct, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TemplateProduct> AddAsync(TemplateProduct templateProduct);
    Task<TemplateProduct> UpdateAsync(TemplateProduct templateProduct);
    Task<TemplateProduct> DeleteAsync(TemplateProduct templateProduct, bool permanent = false);
}
