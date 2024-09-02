using Application.Features.RetailCosts.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.RetailCosts;

public class RetailCostManager : IRetailCostService
{
    private readonly IRetailCostRepository _retailCostRepository;
    private readonly RetailCostBusinessRules _retailCostBusinessRules;

    public RetailCostManager(IRetailCostRepository retailCostRepository, RetailCostBusinessRules retailCostBusinessRules)
    {
        _retailCostRepository = retailCostRepository;
        _retailCostBusinessRules = retailCostBusinessRules;
    }

    public async Task<RetailCost?> GetAsync(
        Expression<Func<RetailCost, bool>> predicate,
        Func<IQueryable<RetailCost>, IIncludableQueryable<RetailCost, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        RetailCost? retailCost = await _retailCostRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return retailCost;
    }

    public async Task<IPaginate<RetailCost>?> GetListAsync(
        Expression<Func<RetailCost, bool>>? predicate = null,
        Func<IQueryable<RetailCost>, IOrderedQueryable<RetailCost>>? orderBy = null,
        Func<IQueryable<RetailCost>, IIncludableQueryable<RetailCost, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<RetailCost> retailCostList = await _retailCostRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return retailCostList;
    }

    public async Task<RetailCost> AddAsync(RetailCost retailCost)
    {
        RetailCost addedRetailCost = await _retailCostRepository.AddAsync(retailCost);

        return addedRetailCost;
    }

    public async Task<RetailCost> UpdateAsync(RetailCost retailCost)
    {
        RetailCost updatedRetailCost = await _retailCostRepository.UpdateAsync(retailCost);

        return updatedRetailCost;
    }

    public async Task<RetailCost> DeleteAsync(RetailCost retailCost, bool permanent = false)
    {
        RetailCost deletedRetailCost = await _retailCostRepository.DeleteAsync(retailCost);

        return deletedRetailCost;
    }
}
