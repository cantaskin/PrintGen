using Application.Features.CustomizedProducts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomizedProducts;

public class CustomizedProductManager : ICustomizedProductService
{
    private readonly ICustomizedProductRepository _customizedProductRepository;
    private readonly CustomizedProductBusinessRules _customizedProductBusinessRules;

    public CustomizedProductManager(ICustomizedProductRepository customizedProductRepository, CustomizedProductBusinessRules customizedProductBusinessRules)
    {
        _customizedProductRepository = customizedProductRepository;
        _customizedProductBusinessRules = customizedProductBusinessRules;
    }

    public async Task<CustomizedProduct?> GetAsync(
        Expression<Func<CustomizedProduct, bool>> predicate,
        Func<IQueryable<CustomizedProduct>, IIncludableQueryable<CustomizedProduct, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomizedProduct? customizedProduct = await _customizedProductRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customizedProduct;
    }

    public async Task<IPaginate<CustomizedProduct>?> GetListAsync(
        Expression<Func<CustomizedProduct, bool>>? predicate = null,
        Func<IQueryable<CustomizedProduct>, IOrderedQueryable<CustomizedProduct>>? orderBy = null,
        Func<IQueryable<CustomizedProduct>, IIncludableQueryable<CustomizedProduct, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomizedProduct> customizedProductList = await _customizedProductRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customizedProductList;
    }

    public async Task<CustomizedProduct> AddAsync(CustomizedProduct customizedProduct)
    {
        CustomizedProduct addedCustomizedProduct = await _customizedProductRepository.AddAsync(customizedProduct);

        return addedCustomizedProduct;
    }

    public async Task<CustomizedProduct> UpdateAsync(CustomizedProduct customizedProduct)
    {
        CustomizedProduct updatedCustomizedProduct = await _customizedProductRepository.UpdateAsync(customizedProduct);

        return updatedCustomizedProduct;
    }

    public async Task<CustomizedProduct> DeleteAsync(CustomizedProduct customizedProduct, bool permanent = false)
    {
        CustomizedProduct deletedCustomizedProduct = await _customizedProductRepository.DeleteAsync(customizedProduct);

        return deletedCustomizedProduct;
    }
}
