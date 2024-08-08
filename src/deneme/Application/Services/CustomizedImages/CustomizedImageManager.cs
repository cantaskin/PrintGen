using Application.Features.CustomizedImages.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomizedImages;

public class CustomizedImageManager : ICustomizedImageService
{
    private readonly ICustomizedImageRepository _customizedImageRepository;
    private readonly CustomizedImageBusinessRules _customizedImageBusinessRules;

    public CustomizedImageManager(ICustomizedImageRepository customizedImageRepository, CustomizedImageBusinessRules customizedImageBusinessRules)
    {
        _customizedImageRepository = customizedImageRepository;
        _customizedImageBusinessRules = customizedImageBusinessRules;
    }

    public async Task<CustomizedImage?> GetAsync(
        Expression<Func<CustomizedImage, bool>> predicate,
        Func<IQueryable<CustomizedImage>, IIncludableQueryable<CustomizedImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomizedImage? customizedImage = await _customizedImageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customizedImage;
    }

    public async Task<IPaginate<CustomizedImage>?> GetListAsync(
        Expression<Func<CustomizedImage, bool>>? predicate = null,
        Func<IQueryable<CustomizedImage>, IOrderedQueryable<CustomizedImage>>? orderBy = null,
        Func<IQueryable<CustomizedImage>, IIncludableQueryable<CustomizedImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomizedImage> customizedImageList = await _customizedImageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customizedImageList;
    }

    public async Task<CustomizedImage> AddAsync(CustomizedImage customizedImage)
    {
        CustomizedImage addedCustomizedImage = await _customizedImageRepository.AddAsync(customizedImage);

        return addedCustomizedImage;
    }

    public async Task<CustomizedImage> UpdateAsync(CustomizedImage customizedImage)
    {
        CustomizedImage updatedCustomizedImage = await _customizedImageRepository.UpdateAsync(customizedImage);

        return updatedCustomizedImage;
    }

    public async Task<CustomizedImage> DeleteAsync(CustomizedImage customizedImage, bool permanent = false)
    {
        CustomizedImage deletedCustomizedImage = await _customizedImageRepository.DeleteAsync(customizedImage);

        return deletedCustomizedImage;
    }
}
