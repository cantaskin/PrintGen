using Application.Features.TemplateProducts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TemplateProducts;

public class TemplateProductManager : ITemplateProductService
{
    private readonly ITemplateProductRepository _templateProductRepository;
    private readonly TemplateProductBusinessRules _templateProductBusinessRules;

    public TemplateProductManager(ITemplateProductRepository templateProductRepository, TemplateProductBusinessRules templateProductBusinessRules)
    {
        _templateProductRepository = templateProductRepository;
        _templateProductBusinessRules = templateProductBusinessRules;
    }

    public async Task<TemplateProduct?> GetAsync(
        Expression<Func<TemplateProduct, bool>> predicate,
        Func<IQueryable<TemplateProduct>, IIncludableQueryable<TemplateProduct, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TemplateProduct? templateProduct = await _templateProductRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return templateProduct;
    }

    public async Task<IPaginate<TemplateProduct>?> GetListAsync(
        Expression<Func<TemplateProduct, bool>>? predicate = null,
        Func<IQueryable<TemplateProduct>, IOrderedQueryable<TemplateProduct>>? orderBy = null,
        Func<IQueryable<TemplateProduct>, IIncludableQueryable<TemplateProduct, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TemplateProduct> templateProductList = await _templateProductRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return templateProductList;
    }

    public async Task<TemplateProduct> AddAsync(TemplateProduct templateProduct)
    {
        TemplateProduct addedTemplateProduct = await _templateProductRepository.AddAsync(templateProduct);

        return addedTemplateProduct;
    }

    public async Task<TemplateProduct> UpdateAsync(TemplateProduct templateProduct)
    {
        TemplateProduct updatedTemplateProduct = await _templateProductRepository.UpdateAsync(templateProduct);

        return updatedTemplateProduct;
    }

    public async Task<TemplateProduct> DeleteAsync(TemplateProduct templateProduct, bool permanent = false)
    {
        TemplateProduct deletedTemplateProduct = await _templateProductRepository.DeleteAsync(templateProduct);

        return deletedTemplateProduct;
    }
}
