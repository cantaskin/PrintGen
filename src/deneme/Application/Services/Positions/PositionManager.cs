using Application.Features.Positions.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Positions;

public class PositionManager : IPositionService
{
    private readonly IPositionRepository _positionRepository;
    private readonly PositionBusinessRules _positionBusinessRules;

    public PositionManager(IPositionRepository positionRepository, PositionBusinessRules positionBusinessRules)
    {
        _positionRepository = positionRepository;
        _positionBusinessRules = positionBusinessRules;
    }

    public async Task<Position?> GetAsync(
        Expression<Func<Position, bool>> predicate,
        Func<IQueryable<Position>, IIncludableQueryable<Position, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Position? position = await _positionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return position;
    }

    public async Task<IPaginate<Position>?> GetListAsync(
        Expression<Func<Position, bool>>? predicate = null,
        Func<IQueryable<Position>, IOrderedQueryable<Position>>? orderBy = null,
        Func<IQueryable<Position>, IIncludableQueryable<Position, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Position> positionList = await _positionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return positionList;
    }

    public async Task<Position> AddAsync(Position position)
    {
        Position addedPosition = await _positionRepository.AddAsync(position);

        return addedPosition;
    }

    public async Task<Position> UpdateAsync(Position position)
    {
        Position updatedPosition = await _positionRepository.UpdateAsync(position);

        return updatedPosition;
    }

    public async Task<Position> DeleteAsync(Position position, bool permanent = false)
    {
        Position deletedPosition = await _positionRepository.DeleteAsync(position);

        return deletedPosition;
    }
}
