using Application.Features.Customizations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Customizations;

public class CustomizationManager : ICustomizationService
{
    private readonly ICustomizationRepository _customizationRepository;
    private readonly CustomizationBusinessRules _customizationBusinessRules;

    public CustomizationManager(ICustomizationRepository customizationRepository, CustomizationBusinessRules customizationBusinessRules)
    {
        _customizationRepository = customizationRepository;
        _customizationBusinessRules = customizationBusinessRules;
    }

    public async Task<Customization?> GetAsync(
        Expression<Func<Customization, bool>> predicate,
        Func<IQueryable<Customization>, IIncludableQueryable<Customization, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Customization? customization = await _customizationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customization;
    }

    public async Task<IPaginate<Customization>?> GetListAsync(
        Expression<Func<Customization, bool>>? predicate = null,
        Func<IQueryable<Customization>, IOrderedQueryable<Customization>>? orderBy = null,
        Func<IQueryable<Customization>, IIncludableQueryable<Customization, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Customization> customizationList = await _customizationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customizationList;
    }

    public async Task<Customization> AddAsync(Customization customization)
    {
        Customization addedCustomization = await _customizationRepository.AddAsync(customization);

        return addedCustomization;
    }

    public async Task<Customization> UpdateAsync(Customization customization)
    {
        Customization updatedCustomization = await _customizationRepository.UpdateAsync(customization);

        return updatedCustomization;
    }

    public async Task<Customization> DeleteAsync(Customization customization, bool permanent = false)
    {
        Customization deletedCustomization = await _customizationRepository.DeleteAsync(customization);

        return deletedCustomization;
    }
}
