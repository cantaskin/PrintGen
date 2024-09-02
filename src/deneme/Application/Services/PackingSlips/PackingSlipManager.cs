using Application.Features.PackingSlips.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.PackingSlips;

public class PackingSlipManager : IPackingSlipService
{
    private readonly IPackingSlipRepository _packingSlipRepository;
    private readonly PackingSlipBusinessRules _packingSlipBusinessRules;

    public PackingSlipManager(IPackingSlipRepository packingSlipRepository, PackingSlipBusinessRules packingSlipBusinessRules)
    {
        _packingSlipRepository = packingSlipRepository;
        _packingSlipBusinessRules = packingSlipBusinessRules;
    }

    public async Task<PackingSlip?> GetAsync(
        Expression<Func<PackingSlip, bool>> predicate,
        Func<IQueryable<PackingSlip>, IIncludableQueryable<PackingSlip, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        PackingSlip? packingSlip = await _packingSlipRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return packingSlip;
    }

    public async Task<IPaginate<PackingSlip>?> GetListAsync(
        Expression<Func<PackingSlip, bool>>? predicate = null,
        Func<IQueryable<PackingSlip>, IOrderedQueryable<PackingSlip>>? orderBy = null,
        Func<IQueryable<PackingSlip>, IIncludableQueryable<PackingSlip, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<PackingSlip> packingSlipList = await _packingSlipRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return packingSlipList;
    }

    public async Task<PackingSlip> AddAsync(PackingSlip packingSlip)
    {
        PackingSlip addedPackingSlip = await _packingSlipRepository.AddAsync(packingSlip);

        return addedPackingSlip;
    }

    public async Task<PackingSlip> UpdateAsync(PackingSlip packingSlip)
    {
        PackingSlip updatedPackingSlip = await _packingSlipRepository.UpdateAsync(packingSlip);

        return updatedPackingSlip;
    }

    public async Task<PackingSlip> DeleteAsync(PackingSlip packingSlip, bool permanent = false)
    {
        PackingSlip deletedPackingSlip = await _packingSlipRepository.DeleteAsync(packingSlip);

        return deletedPackingSlip;
    }
}
