using Application.Features.Layers.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Layers;

public class LayerManager : ILayerService
{
    private readonly ILayerRepository _layerRepository;
    private readonly LayerBusinessRules _layerBusinessRules;

    public LayerManager(ILayerRepository layerRepository, LayerBusinessRules layerBusinessRules)
    {
        _layerRepository = layerRepository;
        _layerBusinessRules = layerBusinessRules;
    }

    public async Task<Layer?> GetAsync(
        Expression<Func<Layer, bool>> predicate,
        Func<IQueryable<Layer>, IIncludableQueryable<Layer, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Layer? layer = await _layerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return layer;
    }

    public async Task<IPaginate<Layer>?> GetListAsync(
        Expression<Func<Layer, bool>>? predicate = null,
        Func<IQueryable<Layer>, IOrderedQueryable<Layer>>? orderBy = null,
        Func<IQueryable<Layer>, IIncludableQueryable<Layer, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Layer> layerList = await _layerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return layerList;
    }

    public async Task<Layer> AddAsync(Layer layer)
    {
        Layer addedLayer = await _layerRepository.AddAsync(layer);

        return addedLayer;
    }

    public async Task<Layer> UpdateAsync(Layer layer)
    {
        Layer updatedLayer = await _layerRepository.UpdateAsync(layer);

        return updatedLayer;
    }

    public async Task<Layer> DeleteAsync(Layer layer, bool permanent = false)
    {
        Layer deletedLayer = await _layerRepository.DeleteAsync(layer);

        return deletedLayer;
    }
}
