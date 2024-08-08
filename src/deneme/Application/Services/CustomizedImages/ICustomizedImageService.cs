using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomizedImages;

public interface ICustomizedImageService
{
    Task<CustomizedImage?> GetAsync(
        Expression<Func<CustomizedImage, bool>> predicate,
        Func<IQueryable<CustomizedImage>, IIncludableQueryable<CustomizedImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomizedImage>?> GetListAsync(
        Expression<Func<CustomizedImage, bool>>? predicate = null,
        Func<IQueryable<CustomizedImage>, IOrderedQueryable<CustomizedImage>>? orderBy = null,
        Func<IQueryable<CustomizedImage>, IIncludableQueryable<CustomizedImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomizedImage> AddAsync(CustomizedImage customizedImage);
    Task<CustomizedImage> UpdateAsync(CustomizedImage customizedImage);
    Task<CustomizedImage> DeleteAsync(CustomizedImage customizedImage, bool permanent = false);
}
