using Application.Features.ProductImages.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductImages;

public class ProductImageManager : IProductImageService
{
    private readonly IProductImageRepository _productImageRepository;
    private readonly ProductImageBusinessRules _productImageBusinessRules;

    public ProductImageManager(IProductImageRepository productImageRepository, ProductImageBusinessRules productImageBusinessRules)
    {
        _productImageRepository = productImageRepository;
        _productImageBusinessRules = productImageBusinessRules;
    }

    public async Task<ProductImage?> GetAsync(
        Expression<Func<ProductImage, bool>> predicate,
        Func<IQueryable<ProductImage>, IIncludableQueryable<ProductImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductImage? productImage = await _productImageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productImage;
    }

    public async Task<IPaginate<ProductImage>?> GetListAsync(
        Expression<Func<ProductImage, bool>>? predicate = null,
        Func<IQueryable<ProductImage>, IOrderedQueryable<ProductImage>>? orderBy = null,
        Func<IQueryable<ProductImage>, IIncludableQueryable<ProductImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductImage> productImageList = await _productImageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productImageList;
    }

    public async Task<ProductImage> AddAsync(ProductImage productImage)
    {
        ProductImage addedProductImage = await _productImageRepository.AddAsync(productImage);

        return addedProductImage;
    }

    public async Task<ProductImage> UpdateAsync(ProductImage productImage)
    {
        ProductImage updatedProductImage = await _productImageRepository.UpdateAsync(productImage);

        return updatedProductImage;
    }

    public async Task<ProductImage> DeleteAsync(ProductImage productImage, bool permanent = false)
    {
        ProductImage deletedProductImage = await _productImageRepository.DeleteAsync(productImage);

        return deletedProductImage;
    }
}
