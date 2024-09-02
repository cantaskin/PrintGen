using Application.Features.Placements.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Placements;

public class PlacementManager : IPlacementService
{
    private readonly IPlacementRepository _placementRepository;
    private readonly PlacementBusinessRules _placementBusinessRules;

    public PlacementManager(IPlacementRepository placementRepository, PlacementBusinessRules placementBusinessRules)
    {
        _placementRepository = placementRepository;
        _placementBusinessRules = placementBusinessRules;
    }

    public async Task<Placement?> GetAsync(
        Expression<Func<Placement, bool>> predicate,
        Func<IQueryable<Placement>, IIncludableQueryable<Placement, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Placement? placement = await _placementRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return placement;
    }

    public async Task<IPaginate<Placement>?> GetListAsync(
        Expression<Func<Placement, bool>>? predicate = null,
        Func<IQueryable<Placement>, IOrderedQueryable<Placement>>? orderBy = null,
        Func<IQueryable<Placement>, IIncludableQueryable<Placement, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Placement> placementList = await _placementRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return placementList;
    }

    public async Task<Placement> AddAsync(Placement placement)
    {
        Placement addedPlacement = await _placementRepository.AddAsync(placement);

        return addedPlacement;
    }

    public async Task<Placement> UpdateAsync(Placement placement)
    {
        Placement updatedPlacement = await _placementRepository.UpdateAsync(placement);

        return updatedPlacement;
    }

    public async Task<Placement> DeleteAsync(Placement placement, bool permanent = false)
    {
        Placement deletedPlacement = await _placementRepository.DeleteAsync(placement);

        return deletedPlacement;
    }
}
