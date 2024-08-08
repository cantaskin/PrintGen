using Application.Features.Colors.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Colors;

public class ColorManager : IColorService
{
    private readonly IColorRepository _colorRepository;
    private readonly ColorBusinessRules _colorBusinessRules;

    public ColorManager(IColorRepository colorRepository, ColorBusinessRules colorBusinessRules)
    {
        _colorRepository = colorRepository;
        _colorBusinessRules = colorBusinessRules;
    }

    public async Task<Color?> GetAsync(
        Expression<Func<Color, bool>> predicate,
        Func<IQueryable<Color>, IIncludableQueryable<Color, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Color? color = await _colorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return color;
    }

    public async Task<IPaginate<Color>?> GetListAsync(
        Expression<Func<Color, bool>>? predicate = null,
        Func<IQueryable<Color>, IOrderedQueryable<Color>>? orderBy = null,
        Func<IQueryable<Color>, IIncludableQueryable<Color, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Color> colorList = await _colorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return colorList;
    }

    public async Task<Color> AddAsync(Color color)
    {
        Color addedColor = await _colorRepository.AddAsync(color);

        return addedColor;
    }

    public async Task<Color> UpdateAsync(Color color)
    {
        Color updatedColor = await _colorRepository.UpdateAsync(color);

        return updatedColor;
    }

    public async Task<Color> DeleteAsync(Color color, bool permanent = false)
    {
        Color deletedColor = await _colorRepository.DeleteAsync(color);

        return deletedColor;
    }
}
